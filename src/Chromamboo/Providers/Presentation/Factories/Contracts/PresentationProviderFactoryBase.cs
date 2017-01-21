using System;

using Chromamboo.Providers.Presentation.Contracts;

using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Presentation.Factories.Contracts
{
    public abstract class PresentationProviderFactoryBase<T> : IPresentationProviderFactory
    {
        public abstract string Name { get;  }
        public Type TypeProduced => typeof(T);
        public abstract IPresentationProvider Create(JToken settings);
    }
}