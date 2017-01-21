using System.Threading.Tasks;

using Chromamboo.Providers.Notification.Contracts;

namespace Chromamboo.Contracts
{
    public interface IBitbucketApi : IPullRequestCountProvider
    {
        Task<string> GetCommitDetails(string commitHash);
    }
}