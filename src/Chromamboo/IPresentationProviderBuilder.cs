using System;
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
            return settings
                .Select(token => new
                {
                    Factory = factories
                        .Where(f => f.Name.Equals(token["provider"].Value<string>(), StringComparison.OrdinalIgnoreCase))
                        .SingleOrDefault(f => typeof(T).IsAssignableFrom(f.TypeProduced)),
                    Settings = token
                })
                .Where(o => o.Factory != null)
                .Select(o => o.Factory.Create(o.Settings))
                .Cast<T>()
                .ToArray();

            //var providers = new List<IPresentationProvider>();


            //for (var i = 0; i < settings.Count; i++)
            //{
            //    var presentationProvider = factories
            //        .Where(f => f.TypeProduced == typeof(T))

            //        .Where(f => f.Name.Equals(settings.ElementAt(i)["provider"].Value<string>()))
            //        .Select(f => f.Create(settings.ElementAt(i)));

            //    providers.Add(presentationProvider);
            //}

            //// TODO: refactor to avoid creating the provider before filtering them with OfType<T>.
            //// Watch out for the settings that can be applied to multiple factories, if they share the "provider" JSON property.
            //return providers;
        }
    }

    public interface IPresentationProviderFactory
    {
        string Name { get;  }
        Type TypeProduced { get;  }
        IPresentationProvider Create(JToken settings);
    }

    public class RazerChromaBuildResultPresentationProviderFactory : PresentationProviderFactoryBase<RazerChromaBuildResultPresentationProvider>
    {
        public override string Name => "razer-chroma";
        public override IPresentationProvider Create(JToken settings)
        {
            // TODO: Keys to light up in configuration
            return new RazerChromaBuildResultPresentationProvider();
        }
    }
    public class RazerChromaPullRequestPresentationProviderFactory : PresentationProviderFactoryBase<RazerChromaPullRequestPresentationProvider>
    {
        public override string Name => "razer-chroma";
        public override IPresentationProvider Create(JToken settings)
        {
            // TODO: Keys to light up in configuration
            return new RazerChromaPullRequestPresentationProvider();
        }
    }

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