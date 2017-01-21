using System.Collections.Generic;

namespace Chromamboo.Providers.Notification.Contracts
{
    public interface INotificationBuilder
    {
        IEnumerable<INotificationProvider> Load(string settingsJson);
    }
}