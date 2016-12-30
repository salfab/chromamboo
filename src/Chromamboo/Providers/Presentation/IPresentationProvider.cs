namespace Chromamboo
{
    using System.Collections.Generic;

    public interface IPresentationProvider
    {
        void Update(List<BuildDetail> buildsDetails, string username);

        void UpdatePRCount(int prCount);

        void MarkAsInconclusive();
    }
}