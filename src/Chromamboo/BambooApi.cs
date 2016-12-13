namespace Chromamboo
{
    using System;
    using System.Configuration;
    using System.Text;
    using System.Threading.Tasks;

    using Chromamboo.Contracts;

    using RestSharp;
    using RestSharp.Authenticators;

    internal class BambooApi : IBambooApi
    {
        private string apiBaseUrl;

        private string password = ConfigurationManager.AppSettings["password"] == null ? "" : Encoding.UTF8.GetString(Convert.FromBase64String(ConfigurationManager.AppSettings["password"]));

        private string username = ConfigurationManager.AppSettings["username"];

        public BambooApi(string apiBaseUrl, string username = null, string secret = null)
        {
            if (secret != null)
            {
                this.password = secret;
            }

            if (username != null)
            {
                this.username = username;
            }

            this.apiBaseUrl = apiBaseUrl;
        }

        public async Task<string> GetBuildResultsAsync(string buildKey)
        {
            var rc = new RestClient(this.apiBaseUrl);
            rc.Authenticator = new HttpBasicAuthenticator(this.username, this.password);
            var request = new RestRequest($"/latest/result/{buildKey}.json");
            rc.Authenticator.Authenticate(rc, request);
            var result = await rc.ExecuteTaskAsync(request);
            return result.Content;
        }

        public async Task<string> GetLatestBuildResultsInHistoryAsync(string planKey)
        {
            var rc = new RestClient(this.apiBaseUrl);
            rc.Authenticator = new HttpBasicAuthenticator(this.username, this.password);
            var request = new RestRequest($"/latest/result/{planKey}.json?max-result=1");
            rc.Authenticator.Authenticate(rc, request);
            var result = await rc.ExecuteTaskAsync(request);
            return result.Content;
        }

        public async Task<string> GetLastBuildResultsWithBranchesAsync(string planKey)
        {
            var rc = new RestClient(this.apiBaseUrl);
            rc.Authenticator = new HttpBasicAuthenticator(this.username,this.password);
            var request = new RestRequest($"/latest/plan/{planKey}/branch.json");
            rc.Authenticator.Authenticate(rc, request);
            var result = await rc.ExecuteTaskAsync(request);
            return result.Content;
        }

        public async Task<string> GetAllBranchesAsync(string planKey)
        {
            var rc = new RestClient(this.apiBaseUrl);
            rc.Authenticator = new HttpBasicAuthenticator(this.username, this.password);
            var request = new RestRequest($"/latest/plan/{planKey}/branch");
            rc.Authenticator.Authenticate(rc, request);
            var result = await rc.ExecuteTaskAsync(request);
            return result.Content;
        }


        public async Task<string> GetLastBuildFromBranchPlan(string key)
        {
            var rc = new RestClient(this.apiBaseUrl);
            rc.Authenticator = new HttpBasicAuthenticator(this.username,this.password);
            var request = new RestRequest($"/latest/result/{key}.json");
            rc.Authenticator.Authenticate(rc, request);
            var result = await rc.ExecuteTaskAsync(request);
            return result.Content;
        }

        public async Task<string> GetBuildDetailsAsync(string key)
        {
            var rc = new RestClient(this.apiBaseUrl);
            rc.Authenticator = new HttpBasicAuthenticator(this.username, this.password);
            var request = new RestRequest($"/latest/result/{key}.json?expand=changes");
            rc.Authenticator.Authenticate(rc, request);
            var result = await rc.ExecuteTaskAsync(request);
            return result.Content;
        }
    }
}