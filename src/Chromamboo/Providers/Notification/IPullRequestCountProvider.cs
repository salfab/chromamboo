namespace Chromamboo.Contracts
{
    using System.Threading.Tasks;

    internal interface IPullRequestCountProvider
    {
        Task<int> GetAwaitingPullRequestCountAsync();
    }
}