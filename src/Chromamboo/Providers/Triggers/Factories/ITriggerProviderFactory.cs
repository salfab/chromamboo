using Chromamboo.Providers.Triggers.Contracts;

using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Triggers.Factories
{
    public interface ITriggerProviderFactory
    {
        string Name { get; }
        ITriggerProvider Create(JObject settings);
    }
}