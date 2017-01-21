using Chromamboo.Providers.Notification.Contracts;

namespace Chromamboo
{
    public class Bootstrapper : IBoostrapper
    {
        private INotificationBuilder notificationBuilder;

        public Bootstrapper(INotificationBuilder notificationBuilder)
        {
            this.notificationBuilder = notificationBuilder;
        }

        public void Start()
        {
            var notificationProviders = this.notificationBuilder.Load("settings.json");
            foreach (var notificationProvider in notificationProviders)
            {
                // TODO: make sure we can have a parameterless Register method. All parameters previouly passed here should be retrieved from the settings.
                notificationProvider.Register();
            }
        }
    }
}