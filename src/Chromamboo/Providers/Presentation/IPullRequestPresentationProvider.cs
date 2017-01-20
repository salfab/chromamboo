namespace Chromamboo.Providers.Presentation
{
    public interface IPullRequestPresentationProvider : IPresentationProvider
    {
        void UpdatePullRequestCount(int pullRequestCount);
        void MarkAsInconclusive();
    }
}