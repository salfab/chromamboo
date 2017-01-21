using System.Collections.Generic;

using Chromamboo.Apis;

namespace Chromamboo.Providers.Presentation.Contracts
{
    public interface IBuildResultPresentationProvider : IPresentationProvider
    {
        void UpdateBuildResults(List<BuildDetail> buildsDetails, string username);
    }
}