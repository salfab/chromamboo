using System;
using Chromamboo.Providers.Notification.Factories.Contracts;
using Chromamboo.Providers.Presentation.Contracts;
using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Notification.Factories
{
    public class GitNotificationProviderFactory : NotificationProviderFactoryBase
    {
        public GitNotificationProviderFactory(ITriggerBuilder triggerBuilder, IPresentationProviderBuilder presentationProviderBuilder) : base(triggerBuilder, presentationProviderBuilder)
        {
        }

        public override string Name => "git";

        public override INotificationProvider Create(dynamic settings)
        {
            IGitNotificationPresentationProvider[] presentationProvider = PresentationProviderBuilder.Build<IGitNotificationPresentationProvider>(settings.presentation);
            return new GitNotificationProvider(presentationProvider);
        }
    }
}