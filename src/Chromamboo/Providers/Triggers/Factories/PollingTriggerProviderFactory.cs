using Chromamboo.Providers.Notification;
using Newtonsoft.Json.Linq;

namespace Chromamboo
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