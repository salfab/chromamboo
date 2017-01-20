using System.Collections.Generic;

namespace Chromamboo.Providers.Presentation
{
    public interface IBuildResultPresentationProvider : IPresentationProvider
    {
        void UpdateBuildResults(List<BuildDetail> buildsDetails, string username);
    }
}