using System.Collections.Generic;

namespace Chromamboo.Providers.Presentation
{
    using Notification;

    public interface IPresentationProvider
    {
        void Update(List<BuildDetail> buildsDetails, string username);

        void UpdatePullRequestCount(int pullRequestCount);

        void MarkAsInconclusive(AtlassianCiSuiteBuildStatusNotificationProvider.NotificationType notificationType);
        string Name { get; }
    }
}