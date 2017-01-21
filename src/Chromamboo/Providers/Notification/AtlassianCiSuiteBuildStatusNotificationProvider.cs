using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Chromamboo.Apis;
using Chromamboo.Contracts;
using Chromamboo.Providers.Notification.Contracts;
using Chromamboo.Providers.Presentation.Contracts;
using Chromamboo.Providers.Triggers.Contracts;

using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Notification
{
    public class AtlassianCiSuiteBuildStatusNotificationProvider : INotificationProvider
    {
        private readonly IBitbucketApi bitbucketApi;

        private readonly IBambooApi bambooApi;
        private readonly ITriggerProvider triggerProvider;

        private readonly IBuildResultPresentationProvider[] presentationProviders;
        private string username;
        private readonly string planKey;

        public AtlassianCiSuiteBuildStatusNotificationProvider(string username, string planKey, IBitbucketApi bitbucketApi, IBambooApi bambooApi, ITriggerProvider triggerProvider, params IBuildResultPresentationProvider[] presentationProviders)
        {
            this.bitbucketApi = bitbucketApi;
            this.bambooApi = bambooApi;
            this.triggerProvider = triggerProvider;
            this.presentationProviders = presentationProviders;
            this.username = username;
            this.planKey = planKey;
        }

        public enum NotificationType
        {
            Build,
            PullRequest
        }

        public void Register()
        {
            this.triggerProvider.WaitForTrigger(async () =>
            {
                await this.PerformPollingAction(this.planKey);                                       
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
                foreach (var provider in this.presentationProviders)
                {
                    provider.MarkAsInconclusive();
                }
                Console.WriteLine(e.GetType() + ": " + e.Message);
                return;
            }
            foreach (var provider in this.presentationProviders)
            {
                provider.UpdateBuildResults(buildsDetails, this.username);
            }
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
            var errorMessage = commitDetails["errors"]?[0]["message"]?.Value<string>();
            if (errorMessage != null)
            {
                throw new InvalidOperationException(errorMessage);
            }

            buildDetails.JiraIssue = commitDetails["properties"]?["jira-key"].Values<string>().Aggregate((s1, s2) => s1 + ", " + s2);
            buildDetails.AuthorEmailAddress = commitDetails["author"]["emailAddress"].Value<string>();
            buildDetails.AuthorName = commitDetails["author"]["name"].Value<string>();
            buildDetails.AuthorDisplayName = commitDetails["author"]["displayName"]?.Value<string>() ?? buildDetails.AuthorName;
            return buildDetails;
        }     
    }
}