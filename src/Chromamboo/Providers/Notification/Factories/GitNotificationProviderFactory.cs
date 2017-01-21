using System;
using Chromamboo.Providers.Notification.Factories.Contracts;
using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Notification.Factories
{
    public class GitNotificationProviderFactory : INotificationProviderFactory
    {
        public string Name => "git";

        public INotificationProvider Create(dynamic settings)
        {
            return null;
        }
    }
}