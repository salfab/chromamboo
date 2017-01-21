using Chromamboo.Providers.Notification;
using Newtonsoft.Json.Linq;

namespace Chromamboo
{
    public abstract class TriggerProviderFactoryBase : ITriggerProviderFactory
    {
        public abstract string Name { get; }
        public abstract ITriggerProvider Create(JObject settings);
    }
}