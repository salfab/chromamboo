using Chromamboo.Providers.Presentation.Contracts;
using Chromamboo.Providers.Presentation.Factories.Contracts;
using Chromamboo.Providers.Presentation.RazerChroma;

using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Presentation.Factories
{
    public class RazerChromaGitNotificationPresentationProviderFactory : PresentationProviderFactoryBase<RazerChromaGitNotificationPresentationProvider>
    {
        public override string Name => "razer-chroma";
        public override IPresentationProvider Create(JToken settings)
        {
            // TODO: Keys to light up in configuration
            return new RazerChromaGitNotificationPresentationProvider();
        }
    }
}