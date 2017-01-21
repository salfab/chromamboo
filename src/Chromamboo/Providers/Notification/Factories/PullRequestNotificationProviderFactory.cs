using System;
using Chromamboo.Providers.Notification.Factories.Contracts;
using Chromamboo.Providers.Presentation;
using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Notification.Factories
{
    public class PullRequestNotificationProviderFactory : NotificationProviderFactoryBase
    {
        public PullRequestNotificationProviderFactory(ITriggerBuilder triggerBuilder, IPresentationProviderBuilder presentationProviderBuilder) : base(triggerBuilder, presentationProviderBuilder)
        {
        }

        public override string Name  => "pull-request";

        public override INotificationProvider Create(dynamic settings)
        {
            var bitbucketSettings = settings.bitbucketSettings;
            IPullRequestCountProvider pullRequestCountProvider = new BitbucketApi(bitbucketSettings.apiBaseUrl.Value, bitbucketSettings.projectKey.Value, bitbucketSettings.repoSlug.Value, bitbucketSettings.username.Value, bitbucketSettings.password.Value);


            var trigger = TriggerBuilder.Build(settings.trigger);
            var presentationProviders = PresentationProviderBuilder.Build<IPullRequestPresentationProvider>(settings.presentation);

            return new PullRequestNotificationProvider(pullRequestCountProvider, trigger, presentationProviders);
        }
    }
}