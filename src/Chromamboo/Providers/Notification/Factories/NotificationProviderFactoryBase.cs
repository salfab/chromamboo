namespace Chromamboo.Providers.Notification.Factories
{
    using Chromamboo.Providers.Notification.Factories.Contracts;

    public abstract class NotificationProviderFactoryBase : INotificationProviderFactory
    {
        protected ITriggerBuilder TriggerBuilder { get; set; }
        protected IPresentationProviderBuilder PresentationProviderBuilder { get; set; }

        protected NotificationProviderFactoryBase(ITriggerBuilder triggerBuilder, IPresentationProviderBuilder presentationProviderBuilder)
        {
            this.TriggerBuilder = triggerBuilder;
            this.PresentationProviderBuilder = presentationProviderBuilder;
        }

        public abstract string Name { get; }
        public abstract INotificationProvider Create(dynamic settings);
    }
}