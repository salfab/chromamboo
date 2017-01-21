using System;

namespace Chromamboo.Providers.Triggers.Contracts
{
    public interface ITriggerProvider
    {
        void WaitForTrigger(Action callback);
    }
}