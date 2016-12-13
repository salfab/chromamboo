using System;
using System.Linq;
using System.Threading.Tasks;
using Chromamboo.Contracts;

using Newtonsoft.Json.Linq;

namespace Chromamboo
{
    class Program
    {
        private static IBambooApi bambooApi;

        private static IBitbucketApi bitbucketApi;

        private static IPresentationService presentationService;

        static void Main(string[] args)
        {
            string username = null;
            string password = null;
            if (args.Length <= 1)
            {
                Console.Write("Chromamboo bambooApiBaseUrl bitbucketApiBaseUrl [username] [password]");
                return;
            }

            var bambooApiBaseUrl = args[0];
            var bitbucketApiBaseUrl = args[1];

            if (args.Length > 3)
            {
                username = args[2];
                password = args[3];
            }
            bambooApi = new BambooApi(bambooApiBaseUrl, username, password);
            bitbucketApi = new BitbucketApi(bitbucketApiBaseUrl, "MYV", "metis", username, password);
            presentationService = new PresentationService(username);

            // TODO: get a push notification from the bamboo server whenever a new build is in.
            while (true)
            {
                try
                {
                    bitbucketApi.GetAwaitingPullRequestCountAsync().ContinueWith(task => presentationService.UpdatePRCount(task.Result));
                    var latestHistoryBuild = bambooApi.GetLatestBuildResultsInHistoryAsync("MYV-MCI");
                    var branchesListing = bambooApi.GetLastBuildResultsWithBranchesAsync("MYV-MCI");

                    var isDevelopSuccessful = JObject.Parse(latestHistoryBuild.Result)["results"]["result"].First()["state"].Value<string>() == "Successful";

                    var lastBuiltBranches = JObject.Parse(branchesListing.Result);
                    var buildsDetails = lastBuiltBranches["branches"]["branch"].Where(b => b["enabled"].Value<bool>()).Select(GetBuildDetails).ToList();

                    if (!isDevelopSuccessful)
                    {
                        var developDetails = bambooApi.GetBuildResultsAsync(JObject.Parse(latestHistoryBuild.Result)["results"]["result"].First()["planResultKey"]["key"].Value<string>());
                        var developBuildDetails = ConstructBuildDetails(developDetails.Result);
                        buildsDetails.Add(developBuildDetails);
                    }

                    presentationService.Update(buildsDetails);

                    Task.Delay(5000).Wait();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetType().Name + " " + e.Message);      
                }
            }
        }

        static private BuildDetail GetBuildDetails(JToken jToken)
        {
            var key = jToken["key"].Value<string>();

            var latestBuildKeyInPlan = JObject.Parse(bambooApi.GetLastBuildFromBranchPlan(key).Result)["results"]["result"].First()["buildResultKey"].Value<string>();

            var buildDetailsString = bambooApi.GetBuildDetailsAsync(latestBuildKeyInPlan).Result;
            var buildDetails = ConstructBuildDetails(buildDetailsString);

            buildDetails.BranchName = jToken["shortName"].Value<string>();
            return buildDetails;
        }

        private static BuildDetail ConstructBuildDetails(string buildDetailsString)
        {
            var details = JObject.Parse(buildDetailsString);

            var buildDetails = new BuildDetail();
            buildDetails.CommitHash = details["vcsRevisionKey"].Value<string>();
            buildDetails.Successful = details["successful"].Value<bool>();

            buildDetails.BuildResultKey = details["buildResultKey"].Value<string>();
            buildDetails.PlanResultKey = details["planResultKey"]["key"].Value<string>();

            var commitDetails = JObject.Parse(bitbucketApi.GetCommitDetails(buildDetails.CommitHash).Result);

            buildDetails.JiraIssue = commitDetails["properties"]?["jira-key"].Values<string>().Aggregate((s1, s2) => s1 + ", " + s2);
            buildDetails.AuthorEmailAddress = commitDetails["author"]["emailAddress"].Value<string>();
            buildDetails.AuthorName = commitDetails["author"]["name"].Value<string>();
            buildDetails.AuthorDisplayName = commitDetails["author"]["displayName"].Value<string>();
            return buildDetails;
        }
    }
}
