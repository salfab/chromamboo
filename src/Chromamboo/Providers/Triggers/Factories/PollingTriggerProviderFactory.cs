using Chromamboo.Providers.Triggers.Contracts;
using Chromamboo.Providers.Triggers.Factories.Contracts;

using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Triggers.Factories
{
    public class PollingTriggerProviderFactory : TriggerProviderFactoryBase
    {
        public override string Name => "polling-trigger";
        public override ITriggerProvider Create(JObject settings)
        {
            return new PollingTriggerProvider(settings["frequence"].Value<long>());
        }
    }
}