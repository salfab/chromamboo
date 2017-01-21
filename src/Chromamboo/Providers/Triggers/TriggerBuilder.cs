using System;
using System.Linq;

using Chromamboo.Providers.Triggers.Contracts;
using Chromamboo.Providers.Triggers.Factories;

namespace Chromamboo.Providers.Triggers
{
    public class TriggerBuilder : ITriggerBuilder
    {
        private readonly ITriggerProviderFactory[] factories;

        public TriggerBuilder(ITriggerProviderFactory[] factories)
        {
            this.factories = factories;
        }

        public ITriggerProvider Build(dynamic trigger)
        {
            // find factory
            var factory = this.factories.Single(f => f.Name.Equals(trigger.provider.Value, StringComparison.OrdinalIgnoreCase));

            // actual creation
            return factory.Create(trigger);
        }
    }
}