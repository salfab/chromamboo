using System.Threading.Tasks;

using Blynclight;

using Chromamboo.Providers.Presentation.Contracts;

namespace Chromamboo.Providers.Presentation
{
    public class BlyncPullRequestPresentationProvider : IPullRequestPresentationProvider
    {
        private const int NumberOfExecutionsBetweenPullRequestNotifications = 3;

        private readonly BlynclightController blynclightController;

        private readonly int selectedBlyncDevice;

        private int numberOfExecutions;
        
        public BlyncPullRequestPresentationProvider(
            BlynclightController blynclightController, 
            int selectedBlyncDevice = 0,
            int numberOfExecutions = 0)
        {
            this.blynclightController = blynclightController;
            this.selectedBlyncDevice = selectedBlyncDevice;
            this.numberOfExecutions = numberOfExecutions;
            this.blynclightController.InitBlyncDevices();
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

        public void MarkAsInconclusive()
        {
            // do nothing yet
        }

        public string Name => "blync";
    }
}