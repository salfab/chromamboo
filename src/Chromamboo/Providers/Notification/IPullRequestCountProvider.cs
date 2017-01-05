namespace Chromamboo.Contracts
{
    using System.Threading.Tasks;

    public interface IPullRequestCountProvider
    {
        Task<int> GetAwaitingPullRequestCountAsync();
    }
}