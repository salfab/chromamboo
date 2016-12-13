namespace Chromamboo.Contracts
{
    using System.Collections.Generic;

    internal interface IPresentationService
    {
        void Update(List<BuildDetail> buildsDetails);

        void UpdatePRCount(int prCount);
    }
}