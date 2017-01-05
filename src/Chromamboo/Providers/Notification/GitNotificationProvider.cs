using System;
using System.Reactive.Linq;

using Chromamboo.Providers.Presentation;
using LibGit2Sharp;

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
            HistoryDivergence divergenceWithDevelop;
            HistoryDivergence divergenceWithRemote;
            using (var repo = new Repository(repositoryPath))
            {
                divergenceWithDevelop = repo.ObjectDatabase.CalculateHistoryDivergence(
                    repo.Head.Tip,
                    repo.Branches["origin/develop"].Tip);
                divergenceWithRemote = repo.ObjectDatabase.CalculateHistoryDivergence(
                    repo.Head.Tip,
                    repo.Branches[repo.Head.RemoteName + "/" + repo.Head.FriendlyName].Tip);
            }

            // update presentation
            foreach (var provider in this.gitPresentationProviders)
            {
                provider.UpdateGitNotification(divergenceWithDevelop, divergenceWithRemote);
            }
        }

        public void Register<T>(T param)
        {
            throw new NotImplementedException();
        }
    }
}