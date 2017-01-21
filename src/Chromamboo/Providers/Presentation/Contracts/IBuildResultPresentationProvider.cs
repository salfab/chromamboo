using System.Collections.Generic;

namespace Chromamboo.Providers.Presentation.Contracts
{
    public interface IBuildResultPresentationProvider : IPresentationProvider
    {
        void UpdateBuildResults(List<BuildDetail> buildsDetails, string username);
    }
}