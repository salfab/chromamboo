namespace Chromamboo.Contracts
{
    using System.Threading.Tasks;

    internal interface IBitbucketApi : IPullRequestCountProvider
    {
        Task<string> GetCommitDetails(string commitHash);
    }
}