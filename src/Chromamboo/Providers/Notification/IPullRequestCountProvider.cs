namespace Chromamboo.Providers.Notification
{
    using System.Threading.Tasks;

    public interface IPullRequestCountProvider
    {
        Task<int> GetAwaitingPullRequestCountAsync();
    }
}