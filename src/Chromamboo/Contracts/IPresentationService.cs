using System.Collections.Generic;

using Chromamboo.Apis;
using Chromamboo.Apis.AtlassianWrappers;

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