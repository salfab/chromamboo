namespace Chromamboo.Contracts
{
    using System.Threading.Tasks;

    internal interface IBitbucketApi
    {
        Task<string> GetCommitDetails(string commitHash);

        Task<int> GetAwaitingPullRequestCountAsync();
    }
}