using System;
using Chromamboo.Providers.Notification.Factories.Contracts;
using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Notification.Factories
{
    public class PullRequestNotificationProviderFactory : INotificationProviderFactory
    {
        public string Name  => "pull-request";

        public INotificationProvider Create(dynamic settings)
        {
            return null;
        }
    }
}