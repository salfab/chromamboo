using Chromamboo.Providers.Notification.Contracts;
using Chromamboo.Providers.Presentation.Contracts;
using Chromamboo.Providers.Triggers.Contracts;

namespace Chromamboo.Providers.Notification
{
    using System;
    using System.Threading.Tasks;

    internal class PullRequestNotificationProvider : INotificationProvider
    {
        private readonly IPullRequestCountProvider pullRequestCountProvider;
        private readonly ITriggerProvider trigger;

        private readonly IPullRequestPresentationProvider[] presentationProviders;

        public PullRequestNotificationProvider(IPullRequestCountProvider pullRequestCountProvider,ITriggerProvider trigger, params IPullRequestPresentationProvider[] presentationProviders)
        {
            this.pullRequestCountProvider = pullRequestCountProvider;
            this.trigger = trigger;
            this.presentationProviders = presentationProviders;
        }       

        public void Register()
        {
            this.trigger.WaitForTrigger(async () =>
            {
                await this.PerformPollingAction();
            });
        }

        private async Task PerformPollingAction()
        {
            int count;
            try
            {
                count = await this.pullRequestCountProvider.GetAwaitingPullRequestCountAsync();
            }
            catch (Exception e)
            {
                foreach (var provider in this.presentationProviders)
                {
                    provider.MarkAsInconclusive();
                }

                // TODO: consider accepting exceptions in MarkAsInconclusive and make it a first-class citizen presentationProvider.
                Console.WriteLine(e.GetType() + ": " + e.Message);
                return;
            }
            foreach (var provider in this.presentationProviders)
            {
                provider.UpdatePullRequestCount(count);
            }
        }
    }
}