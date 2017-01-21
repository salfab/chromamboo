using Chromamboo.Apis;
using Chromamboo.Contracts;
using Chromamboo.Providers.Notification.Contracts;
using Chromamboo.Providers.Presentation.Contracts;
using Chromamboo.Providers.Triggers.Contracts;

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
            return new AtlassianCiSuiteBuildStatusNotificationProvider(settings.username.Value, settings.planKey.Value, bitbucketApi, bambooApi, trigger, presentationProviders);
        }
    }
}