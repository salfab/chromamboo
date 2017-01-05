﻿namespace Chromamboo.Providers.Notification
{
    using System;
    using System.Reactive.Linq;
    using System.Threading.Tasks;

    using Chromamboo.Contracts;

    internal class PullRequestsNotificationProvider : INotificationProvider<object>
    {
        private readonly IPullRequestCountProvider pullRequestCountProvider;

        private readonly IPresentationService presentationService;

        public PullRequestsNotificationProvider(IPullRequestCountProvider pullRequestCountProvider, IPresentationService presentationService)
        {
            this.pullRequestCountProvider = pullRequestCountProvider;
            this.presentationService = presentationService;
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
                this.presentationService.MarkAsInconclusive(AtlassianCiSuiteBuildStatusNotificationProvider.NotificationType.PullRequest);
                Console.WriteLine(e.GetType() + ": " + e.Message);
                return;
            }

            this.presentationService.UpdatePullRequestCount(count);             
        }
    }
}