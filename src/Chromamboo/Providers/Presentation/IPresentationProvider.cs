namespace Chromamboo
{
    using System.Collections.Generic;

    public interface IPresentationProvider
    {
        void Update(List<BuildDetail> buildsDetails, string username);

        void UpdatePrCount(int pullRequestCount);

        void MarkAsInconclusive(AtlassianCiSuiteBuildStatusNotificationProvider.NotificationType notificationType);
    }
}