using Chromamboo.Providers.Notification;
using Newtonsoft.Json.Linq;

namespace Chromamboo
{
    public interface ITriggerProviderFactory
    {
        string Name { get; }
        ITriggerProvider Create(JObject settings);
    }
}