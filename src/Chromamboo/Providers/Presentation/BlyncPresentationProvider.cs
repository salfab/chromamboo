using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blynclight;

namespace Chromamboo.Providers.Presentation
{
    using Notification;

    public class BlyncPresentationProvider : IPresentationProvider
    {
        private const int NumberOfExecutionsBetweenPullRequestNotifications = 3;

        private readonly BlynclightController blynclightController;

        private readonly int selectedBlyncDevice;

        private int numberOfExecutions;
        
        public BlyncPresentationProvider(
            BlynclightController blynclightController, 
            int selectedBlyncDevice)
        {
            this.blynclightController = blynclightController;
            this.selectedBlyncDevice = selectedBlyncDevice;
        }

        public void Update(List<BuildDetail> buildsDetails, string username)
        {
            var isAnyBroken = buildsDetails.Any(b => !b.Successful && b.AuthorName != username);
            var isMineBroken = buildsDetails.Any(b => !b.Successful && b.AuthorName == username);
            var isDevelopBroken = buildsDetails.Any(b => !b.Successful && b.BranchName == "develop");

            if (isMineBroken)
            {
                this.blynclightController.TurnOnYellowLight(this.selectedBlyncDevice);
            }

            if (isDevelopBroken)
            {
                this.blynclightController.TurnOnRedLight(this.selectedBlyncDevice);
            }

            if (isAnyBroken && !isMineBroken && !isDevelopBroken)
            {
                this.blynclightController.TurnOnBlueLight(this.selectedBlyncDevice);
            }

            if (!isMineBroken && !isDevelopBroken && !isAnyBroken)
            {
                this.blynclightController.TurnOnGreenLight(this.selectedBlyncDevice);
            }
        }

        public void UpdatePullRequestCount(int pullRequestCount)
        {
            if (pullRequestCount > 0)
            {
                if (this.numberOfExecutions == 0)
                {
                    this.blynclightController.TurnOnMagentaLight(this.selectedBlyncDevice);
                    Task.Delay(1000).Wait();
                }

                if (++this.numberOfExecutions == NumberOfExecutionsBetweenPullRequestNotifications)
                {
                    this.numberOfExecutions = 0;
                }
            }
            else
            {
                this.numberOfExecutions = 0;
            }
        }

        public void MarkAsInconclusive(AtlassianCiSuiteBuildStatusNotificationProvider.NotificationType notificationType)
        {
            // do nothing yet
        }
    }
}