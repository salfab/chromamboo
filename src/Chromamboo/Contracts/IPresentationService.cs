namespace Chromamboo.Contracts
{
    using System.Collections.Generic;

    public interface IPresentationService
    {
        void Update(List<BuildDetail> buildsDetails);

        void UpdatePRCount(int prCount);
        void MarkAsInconclusive(AtlassianCiSuiteBuildStatusNotificationProvider.NotificationType notificationType);
    }
}