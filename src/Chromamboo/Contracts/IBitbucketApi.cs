using System.Threading.Tasks;

using Chromamboo.Providers.Notification;

namespace Chromamboo.Contracts
{
    public interface IBitbucketApi : IPullRequestCountProvider
    {
        Task<string> GetCommitDetails(string commitHash);
    }
}