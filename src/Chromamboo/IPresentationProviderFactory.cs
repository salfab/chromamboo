namespace Chromamboo
{
    using System;

    using Chromamboo.Providers.Presentation.Contracts;

    using Newtonsoft.Json.Linq;

    public interface IPresentationProviderFactory
    {
        string Name { get;  }
        Type TypeProduced { get;  }
        IPresentationProvider Create(JToken settings);
    }
}