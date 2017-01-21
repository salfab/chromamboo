using System.Collections.Generic;

using Chromamboo.Apis;
using Chromamboo.Apis.AtlassianWrappers;

namespace Chromamboo.Providers.Presentation.Contracts
{
    public interface IBuildResultPresentationProvider : IPresentationProvider
    {
        void UpdateBuildResults(List<BuildDetail> buildsDetails, string username);
    }
}