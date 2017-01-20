using System;
using System.Reactive.Linq;

namespace Chromamboo.Providers.Notification
{
    public class PollingNotificationTrigger : INotificationTrigger
    {
        public void WaitForTrigger(Action callback)
        {
            Observable
                .Timer(DateTimeOffset.MinValue, TimeSpan.FromSeconds(30))
                .Subscribe(l => { callback(); });
        }
    }
}