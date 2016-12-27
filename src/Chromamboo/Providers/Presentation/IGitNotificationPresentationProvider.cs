namespace Chromamboo.Providers.Presentation
{
    using Chromamboo.Providers.Notification;

    /// <summary>
    /// THis interface must be implemented by all providers compatible with the <see cref="GitNotificationProvider"/>.
    /// </summary>
    internal interface IGitNotificationPresentationProvider
    {
        void UpdateGitNotification();
    }
}