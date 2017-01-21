using System;
using Chromamboo.Contracts;
using Chromamboo.Providers.Notification.Factories.Contracts;
using Chromamboo.Providers.Presentation.Contracts;
using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Notification.Factories
{
    public class AtlassianCiSuiteBuildStatusNotificationProviderFactory : NotificationProviderFactoryBase
    {        

        public AtlassianCiSuiteBuildStatusNotificationProviderFactory(ITriggerBuilder triggerBuilder, IPresentationProviderBuilder presentationProviderBuilder) : base(triggerBuilder, presentationProviderBuilder)
        {    
        }

        public override string Name => "Atlassian-ci";

        public override INotificationProvider Create(dynamic settings)
        {
            // fixed part
            IBitbucketApi bitbucketApi = new BitbucketApi(settings.bitbucketSettings.apiBaseUrl.Value, settings.bitbucketSettings.projectKey.Value, settings.bitbucketSettings.repoSlug.Value, settings.bitbucketSettings.username.Value, settings.bitbucketSettings.password.Value);
            IBambooApi bambooApi = new BambooApi(settings.bambooSettings.apiBaseUrl.Value, settings.bambooSettings.username.Value, settings.bambooSettings.password.Value);

            // variable part
            IBuildResultPresentationProvider[] presentationProviders = PresentationProviderBuilder.Build<IBuildResultPresentationProvider>(settings.presentation);
            ITriggerProvider trigger = TriggerBuilder.Build(settings.trigger);
            return new AtlassianCiSuiteBuildStatusNotificationProvider(settings.username.Value, bitbucketApi, bambooApi, trigger, presentationProviders);
        }
    }

    public abstract class NotificationProviderFactoryBase : INotificationProviderFactory
    {
        protected ITriggerBuilder TriggerBuilder { get; set; }
        protected IPresentationProviderBuilder PresentationProviderBuilder { get; set; }

        protected NotificationProviderFactoryBase(ITriggerBuilder triggerBuilder, IPresentationProviderBuilder presentationProviderBuilder)
        {
            TriggerBuilder = triggerBuilder;
            PresentationProviderBuilder = presentationProviderBuilder;
        }

        public abstract string Name { get; }
        public abstract INotificationProvider Create(dynamic settings);
    }
}