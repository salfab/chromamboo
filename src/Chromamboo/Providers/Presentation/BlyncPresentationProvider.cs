using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blynclight;

namespace Chromamboo.Providers.Presentation
{
    using System;

    using Notification;

    public class BlyncPresentationProvider : IPresentationProvider
    {
        private const int NumberOfExecutionsBetweenPullRequestNotifications = 3;

        private readonly BlynclightController blynclightController;

        private readonly int selectedBlyncDevice;

        private int numberOfExecutions;
        
        public BlyncPresentationProvider(
            BlynclightController blynclightController, 
            int selectedBlyncDevice = 0,
            int numberOfExecutions = 0)
        {
            this.blynclightController = blynclightController;
            this.selectedBlyncDevice = selectedBlyncDevice;
            this.numberOfExecutions = numberOfExecutions;
            this.blynclightController.InitBlyncDevices();
        }

        public void Update(List<BuildDetail> buildsDetails, string username)
        {
            var buildBrokenByAny = buildsDetails.Where(b => !b.Successful && b.AuthorName != username).ToArray();
            var isAnyBroken = buildBrokenByAny.Any();

            var buildBrokenByMe = buildsDetails.Where(b => !b.Successful && b.AuthorName == username).ToArray();
            var isMineBroken = buildBrokenByMe.Any();

            var buildDevelopBroken = buildsDetails.Where(b => !b.Successful && b.BranchName == "develop").ToArray();
            var isDevelopBroken = buildDevelopBroken.Any();

            if (isMineBroken)
            {
                this.blynclightController.TurnOnYellowLight(this.selectedBlyncDevice);
                Console.WriteLine($"{DateTime.Now} {string.Join(",", buildBrokenByMe.Select(s => s.AuthorName))} broke {string.Join(",", buildBrokenByMe.Select(s => s.BranchName))}");
            }

            if (isDevelopBroken)
            {
                this.blynclightController.TurnOnRedLight(this.selectedBlyncDevice);
                Console.WriteLine($"{DateTime.Now} {string.Join(",", buildDevelopBroken.Select(s => s.AuthorName))} broke {string.Join(",", buildDevelopBroken.Select(s => s.BranchName))}");
            }

            if (isAnyBroken && !isMineBroken && !isDevelopBroken)
            {
                this.blynclightController.TurnOnBlueLight(this.selectedBlyncDevice);
                Console.WriteLine($"{DateTime.Now} {string.Join(",", buildBrokenByAny.Select(s => s.AuthorName))} broke {string.Join(",", buildBrokenByAny.Select(s => s.BranchName))}");
            }

            if (!isMineBroken && !isDevelopBroken && !isAnyBroken)
            {
                this.blynclightController.TurnOnGreenLight(this.selectedBlyncDevice);
                Console.WriteLine($"{DateTime.Now} You guys are the best.");
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