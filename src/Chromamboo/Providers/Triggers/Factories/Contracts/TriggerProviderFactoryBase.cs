using Chromamboo.Providers.Triggers.Contracts;

using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Triggers.Factories.Contracts
{
    public abstract class TriggerProviderFactoryBase : ITriggerProviderFactory
    {
        public abstract string Name { get; }

        public abstract ITriggerProvider Create(JObject settings);
    }
}