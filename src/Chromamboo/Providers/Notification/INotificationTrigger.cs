using System;

namespace Chromamboo.Providers.Notification
{
    internal interface INotificationTrigger
    {
        void WaitForTrigger(Action callback);
    }
}