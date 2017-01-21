using System;

using Chromamboo.Providers.Presentation.Contracts;

using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Presentation.Factories.Contracts
{
    public interface IPresentationProviderFactory
    {
        string Name { get;  }
        Type TypeProduced { get;  }
        IPresentationProvider Create(JToken settings);
    }
}