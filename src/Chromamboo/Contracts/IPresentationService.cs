using System.Collections.Generic;

namespace Chromamboo.Contracts
{
    using Providers.Notification;

    public interface IPresentationService
    {
        void Update(List<BuildDetail> buildsDetails);

        void UpdatePullRequestCount(int pullRequestCount);

        void MarkAsInconclusive(AtlassianCiSuiteBuildStatusNotificationProvider.NotificationType notificationType);
    }
}