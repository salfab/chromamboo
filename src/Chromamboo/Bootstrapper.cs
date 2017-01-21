using Chromamboo.Providers.Notification.Contracts;

namespace Chromamboo
{
    public class Bootstrapper : IBoostrapper
    {
        private readonly INotificationBuilder notificationBuilder;

        public Bootstrapper(INotificationBuilder notificationBuilder)
        {
            this.notificationBuilder = notificationBuilder;
        }

        public void Start()
        {
            var notificationProviders = this.notificationBuilder.Load("settings.json");
            foreach (var notificationProvider in notificationProviders)
            {
                notificationProvider.Register();
            }
        }
    }
}