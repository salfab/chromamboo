using System;

namespace Chromamboo.Providers.Notification
{
    public interface ITriggerProvider
    {
        void WaitForTrigger(Action callback);
    }
}