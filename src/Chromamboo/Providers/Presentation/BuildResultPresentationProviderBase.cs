using System;
using System.Collections.Generic;
using System.Linq;

using Chromamboo.Apis.AtlassianWrappers;

namespace Chromamboo.Providers.Presentation
{
    public class BuildResultPresentationProviderBase 
    {
        protected bool IsMineBroken(List<BuildDetail> buildsDetails, string username)
        {
            return buildsDetails.Any(b => !b.Successful && b.AuthorName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        protected bool IsAnyBroken(List<BuildDetail> buildsDetails)
        {
            return buildsDetails.Any(b => !b.Successful);
        }
    }
}