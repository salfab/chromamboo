using System;
using System.Linq;

using Chromamboo.Providers.Presentation.Contracts;
using Chromamboo.Providers.Presentation.Factories.Contracts;

using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Presentation
{
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
                                         Factory = this.factories
                                     .Where(f => f.Name.Equals(Extensions.Value<string>(token["provider"]), StringComparison.OrdinalIgnoreCase))
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
}