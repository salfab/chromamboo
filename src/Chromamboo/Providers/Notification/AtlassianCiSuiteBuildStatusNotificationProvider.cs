using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

using Chromamboo.Contracts;

using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Notification
{
    public class AtlassianCiSuiteBuildStatusNotificationProvider : INotificationProvider<string>
    {
        private readonly IBitbucketApi bitbucketApi;

        private readonly IBambooApi bambooApi;

        private readonly IPresentationService presentationService;

        public AtlassianCiSuiteBuildStatusNotificationProvider(IBitbucketApi bitbucketApi, IBambooApi bambooApi, IPresentationService presentationService)
        {
            this.bitbucketApi = bitbucketApi;
            this.bambooApi = bambooApi;
            this.presentationService = presentationService;
        }

        public enum NotificationType
        {
            Build,
            PullRequest
        }

        public void Register(string planKey)
        {
            Observable
                .Timer(DateTimeOffset.MinValue, TimeSpan.FromSeconds(5))
                .Subscribe(async l =>
                    {                                                
                            await this.PerformPollingAction(planKey);                       
                    });
        }

        private async Task PerformPollingAction(string planKey)
        {
            List<BuildDetail> buildsDetails;
            try
            {
                var latestHistoryBuild = this.bambooApi.GetLatestBuildResultsInHistoryAsync(planKey);
                var branchesListing = this.bambooApi.GetLastBuildResultsWithBranchesAsync(planKey);

                var isDevelopSuccessful = JObject.Parse(latestHistoryBuild.Result)["results"]["result"].First()["state"].Value<string>() == "Successful";

                var lastBuiltBranches = JObject.Parse(branchesListing.Result);
                buildsDetails = lastBuiltBranches["branches"]["branch"].Where(b => b["enabled"].Value<bool>()).Select(this.GetBuildDetails).ToList();

                if (!isDevelopSuccessful)
                {
                    var developDetails = this.bambooApi.GetBuildResultsAsync(JObject.Parse(latestHistoryBuild.Result)["results"]["result"].First()["planResultKey"]["key"].Value<string>());
                    var developBuildDetails = this.ConstructBuildDetails(developDetails.Result);
                    buildsDetails.Add(developBuildDetails);
                }
            }
            catch (Exception e)
            {
                this.presentationService.MarkAsInconclusive(NotificationType.Build);
                Console.WriteLine(e.GetType() + ": " + e.Message);
                return;
            }

            this.presentationService.Update(buildsDetails);
        }

        private BuildDetail GetBuildDetails(JToken jsonToken)
        {
            var key = jsonToken["key"].Value<string>();

            var latestBuildKeyInPlan = JObject.Parse(this.bambooApi.GetLastBuildFromBranchPlan(key).Result)["results"]["result"].First()["buildResultKey"].Value<string>();

            var buildDetailsString = this.bambooApi.GetBuildDetailsAsync(latestBuildKeyInPlan).Result;
            var buildDetails = this.ConstructBuildDetails(buildDetailsString);

            buildDetails.BranchName = jsonToken["shortName"].Value<string>();
            return buildDetails;
        }
        
        private BuildDetail ConstructBuildDetails(string buildDetailsString)
        {
            var details = JObject.Parse(buildDetailsString);

            var buildDetails = new BuildDetail();
            buildDetails.CommitHash = details["vcsRevisionKey"].Value<string>();
            buildDetails.Successful = details["successful"].Value<bool>();
            buildDetails.BuildResultKey = details["buildResultKey"].Value<string>();
            buildDetails.PlanResultKey = details["planResultKey"]["key"].Value<string>();

            var commitDetails = JObject.Parse(this.bitbucketApi.GetCommitDetails(buildDetails.CommitHash).Result);

            buildDetails.JiraIssue = commitDetails["properties"]?["jira-key"].Values<string>().Aggregate((s1, s2) => s1 + ", " + s2);
            buildDetails.AuthorEmailAddress = commitDetails["author"]["emailAddress"].Value<string>();
            buildDetails.AuthorName = commitDetails["author"]["name"].Value<string>();
            buildDetails.AuthorDisplayName = commitDetails["author"]["displayName"]?.Value<string>() ?? buildDetails.AuthorName;
            return buildDetails;
        }     
    }
}