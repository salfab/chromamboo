using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Presentation.Contracts
{
    public interface IPresentationProviderBuilder
    {
        T[] Build<T>(JArray settings);
    }
}