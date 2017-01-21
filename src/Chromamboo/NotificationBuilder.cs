using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Chromamboo.Providers.Notification;
using Chromamboo.Providers.Notification.Factories;
using Chromamboo.Providers.Notification.Factories.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Chromamboo
{
    public interface INotificationBuilder
    {
        void Load(string settingsJson);
    }

    public class NotificationBuilder : INotificationBuilder
    {
        private readonly INotificationProviderFactory[] notificationProviderFactories;

        public NotificationBuilder(INotificationProviderFactory[] notificationProviderFactories)
        {
            this.notificationProviderFactories = notificationProviderFactories;
        }

        public NotificationBuilder()
        {
        }

        private Dictionary<string, Func<JObject, INotificationProvider>> LoadNotificationProviderFactories()
        {          
            return null;
        }


        public void Load(string settingsJson)
        {
            var notificationProviders = LoadNotificationProviderFactories();

            JToken settings;
            using (var file = File.OpenText(settingsJson))
            using (var reader = new JsonTextReader(file))
            {
                settings = JToken.Load(reader);
            }
            var notifications = settings["notifications"];
            foreach (dynamic notification in notifications)
            {
                Console.WriteLine("Loading notification " + notification.displayName);
                var factory = this.notificationProviderFactories.Single(f => f.Name.Equals((string)notification.provider,StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("found provider " + notification.provider);
                var provider = factory.Create(notification);
            }
        }
    }
}