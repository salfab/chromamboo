namespace Chromamboo.Contracts
{
    using System.Threading.Tasks;

    public interface IBambooApi
    {
        Task<string> GetBuildResultsAsync(string buildKey);

        Task<string> GetBuildDetailsAsync(string key);

        Task<string> GetAllBranchesAsync(string planKey);

        Task<string> GetLastBuildResultsWithBranchesAsync(string planKey);

        Task<string> GetLatestBuildResultsInHistoryAsync(string planKey);

        Task<string> GetLastBuildFromBranchPlan(string key);
    }
}