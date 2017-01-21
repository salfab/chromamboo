using Chromamboo.Providers.Notification;
using LibGit2Sharp;

namespace Chromamboo.Providers.Presentation.Contracts
{
    /// <summary>
    /// THis interface must be implemented by all providers compatible with the <see cref="GitNotificationProvider"/>.
    /// </summary>
    internal interface IGitNotificationPresentationProvider
    {        
        void UpdateGitNotification(HistoryDivergence divergenceWithDevelop, HistoryDivergence divergenceWithRemote);
        string Name { get; }
    }
}