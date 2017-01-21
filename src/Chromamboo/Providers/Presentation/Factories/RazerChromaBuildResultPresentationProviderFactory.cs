using Chromamboo.Providers.Presentation.Contracts;
using Chromamboo.Providers.Presentation.Factories.Contracts;

using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Presentation.Factories
{
    public class RazerChromaBuildResultPresentationProviderFactory : PresentationProviderFactoryBase<RazerChromaBuildResultPresentationProvider>
    {
        public override string Name => "razer-chroma";
        public override IPresentationProvider Create(JToken settings)
        {
            // TODO: Keys to light up in configuration
            return new RazerChromaBuildResultPresentationProvider();
        }
    }
}