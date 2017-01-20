using Chromamboo.Providers.Presentation;

namespace Chromamboo.Providers.Notification
{
    using System;
    using System.Reactive.Linq;
    using System.Threading.Tasks;

    using Chromamboo.Contracts;

    internal class PullRequestsNotificationProvider : INotificationProvider<object>
    {
        private readonly IPullRequestCountProvider pullRequestCountProvider;

        private readonly IPullRequestPresentationProvider[] presentationProviders;

        public PullRequestsNotificationProvider(IPullRequestCountProvider pullRequestCountProvider, params IPullRequestPresentationProvider[] presentationProviders)
        {
            this.pullRequestCountProvider = pullRequestCountProvider;
            this.presentationProviders = presentationProviders;
        }

        [Obsolete("Use the parameterless implementation as the param will never be used.")]
        public void Register(object param = null)
        {
            this.Register();
        }

        public void Register()
        {
            Observable.Timer(DateTimeOffset.MinValue, TimeSpan.FromSeconds(30))
                .Subscribe(async l => { await this.PerformPollingAction(); });
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