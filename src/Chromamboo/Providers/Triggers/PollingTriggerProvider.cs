using System;
using System.Reactive.Linq;

using Chromamboo.Providers.Triggers.Contracts;

namespace Chromamboo.Providers.Triggers
{
    public class PollingTriggerProvider : ITriggerProvider
    {
        private readonly long frequence;

        public PollingTriggerProvider(long frequence)
        {
            this.frequence = frequence; 
        }

        public void WaitForTrigger(Action callback)
        {
            Observable
                .Timer(DateTimeOffset.MinValue, TimeSpan.FromMilliseconds(this.frequence))
                .Subscribe(l => { callback(); });
        }
    }
}