using Chromamboo.Providers.Presentation;

namespace Chromamboo.Providers.Notification
{
    using System;
    using System.Reactive.Linq;
    using System.Threading.Tasks;

    internal class PullRequestNotificationProvider : INotificationProvider<object>
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

        [Obsolete("Use the parameterless implementation as the param will never be used.")]
        public void Register(object param = null)
        {
            this.Register();
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