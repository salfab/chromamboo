using System.Collections.Generic;

using Newtonsoft.Json.Linq;

namespace Chromamboo
{
    public interface IPresentationProviderBuilder
    {
        T[] Build<T>(JArray settings);
    }
}