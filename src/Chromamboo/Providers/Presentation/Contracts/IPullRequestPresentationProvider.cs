namespace Chromamboo.Providers.Presentation.Contracts
{
    public interface IPullRequestPresentationProvider : IPresentationProvider
    {
        void UpdatePullRequestCount(int pullRequestCount);
    }
}