namespace Chromamboo
{
    using Chromamboo.Providers.Presentation;
    using Chromamboo.Providers.Presentation.Contracts;

    using Newtonsoft.Json.Linq;

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