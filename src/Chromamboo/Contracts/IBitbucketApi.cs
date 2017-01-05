namespace Chromamboo.Contracts
{
    using System.Threading.Tasks;

    public interface IBitbucketApi : IPullRequestCountProvider
    {
        Task<string> GetCommitDetails(string commitHash);
    }
}