namespace Chromamboo
{
    using System.Collections.Generic;

    using Chromamboo.Providers.Notification;

    public interface INotificationBuilder
    {
        IEnumerable<INotificationProvider> Load(string settingsJson);
    }
}