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
                                             .Where(f => f.Name.Equals(token["provider"].Value<string>(), StringComparison.OrdinalIgnoreCase))
                                             .SingleOrDefault(f => typeof(T).IsAssignableFrom(f.TypeProduced)),
                                         Settings = token
                                     })
                .Where(o => o.Factory != null)
                .Select(o => o.Factory.Create(o.Settings))
                .Cast<T>()
                .ToArray();      
        }
    }
}