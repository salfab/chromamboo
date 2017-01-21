using System.Threading.Tasks;

namespace Chromamboo.Providers.Notification.Contracts
{
    public interface IPullRequestCountProvider
    {
        Task<int> GetAwaitingPullRequestCountAsync();
    }
}