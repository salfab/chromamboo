namespace Chromamboo.Apis.AtlassianWrappers
{
    public class BuildDetail
    {
        public string BuildResultKey { get; set; }

        public string CommitHash { get; set; }

        public bool Successful { get; set; }

        public string BranchName { get; set; }

        public string PlanResultKey { get; set; }

        public string JiraIssue { get; set; }

        public string AuthorEmailAddress { get; set; }

        public string AuthorName { get; set; }

        public string AuthorDisplayName { get; set; }
    }
}