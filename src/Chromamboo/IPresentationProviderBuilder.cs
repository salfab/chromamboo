using System.Collections.Generic;
using System.Linq;
using Chromamboo.Providers.Presentation;
using Chromamboo.Providers.Presentation.Contracts;
using Newtonsoft.Json.Linq;

namespace Chromamboo
{
    public interface IPresentationProviderBuilder
    {
        T[] Build<T>(JArray settings);
    }

    public class PresentationProviderBuilder : IPresentationProviderBuilder
    {
        private readonly IPresentationProviderFactory[] factories;

        public PresentationProviderBuilder(IPresentationProviderFactory[] factories)
        {
            this.factories = factories;
        }

        public T[] Build<T>(JArray settings) 
        {
            var providers = new List<IPresentationProvider>();

            // TODO: invert factories with settings so we can save a call to ToArray.
            for (var i = 0; i < settings.Count; i++)
            {
                providers.AddRange(factories
                    .Where(f => f.Name.Equals(settings.ElementAt(i)["provider"].Value<string>()))
                    .Select( f => f.Create(settings.ElementAt(i))));
            }
            return providers.OfType<T>().ToArray();
        }
    }

    public interface IPresentationProviderFactory
    {
        string Name { get;  }
        IPresentationProvider Create(JToken settings);
    }

    public class RazerChromaBuildResultPresentationProviderFactory : IPresentationProviderFactory
    {
        public string Name => "razer-chroma";
        public IPresentationProvider Create(JToken settings)
        {
            // TODO: Keys to light up in configuration
            return new RazerChromaBuildResultPresentationProvider();
        }
    }
    public class RazerChromaPullRequestPresentationProviderFactory : IPresentationProviderFactory
    {
        public string Name => "razer-chroma";
        public IPresentationProvider Create(JToken settings)
        {
            // TODO: Keys to light up in configuration
            return new RazerChromaPullRequestPresentationProvider();
        }
    }

    public class RazerChromaGitNotificationPresentationProviderFactory : IPresentationProviderFactory
    {
        public string Name => "razer-chroma";
        public IPresentationProvider Create(JToken settings)
        {
            // TODO: Keys to light up in configuration
            return new RazerChromaGitNotificationPresentationProvider();
        }
    }
}