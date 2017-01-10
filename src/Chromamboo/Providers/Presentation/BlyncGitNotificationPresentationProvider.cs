using LibGit2Sharp;

namespace Chromamboo.Providers.Presentation
{
    public class BlyncGitNotificationPresentationProvider : IGitNotificationPresentationProvider
    {
        public void UpdateGitNotification(HistoryDivergence divergenceWithDevelop, HistoryDivergence divergenceWithRemote)
        {
            // do nothing 
        }

        public string Name => "blync";
    }
}