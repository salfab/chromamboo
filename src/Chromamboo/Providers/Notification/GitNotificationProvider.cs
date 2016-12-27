using System;
using System.Reactive.Linq;

using Chromamboo.Providers.Presentation;

namespace Chromamboo.Providers.Notification
{
    internal class GitNotificationProvider : INotificationProvider<string>
    {
        private readonly IGitNotificationPresentationProvider[] gitPresentationProviders;

        public GitNotificationProvider(IGitNotificationPresentationProvider[] gitPresentationProviders)
        {
            this.gitPresentationProviders = gitPresentationProviders;
        }

        public void Register(string repositoryPath)
        {
            Observable
                .Timer(DateTimeOffset.MinValue, TimeSpan.FromSeconds(5))
                .Subscribe(l => this.PerformPollingAction(repositoryPath));
        }

        private void PerformPollingAction(string repositoryPath)
        {
            // query git difference between current branch and develop

            // update presentation
            foreach (var provider in this.gitPresentationProviders)
            {
                provider.UpdateGitNotification();
            }
        }

        public void Register<T>(T param)
        {
            throw new NotImplementedException();
        }
    }
}