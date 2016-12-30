using System.Collections.Generic;

using Chromamboo.Contracts;

namespace Chromamboo
{
    public class PresentationService : IPresentationService
    {
        private readonly IPresentationProvider[] presentationProviders;

        private readonly string username;

        public PresentationService(string username, IPresentationProvider[] presentationProviders)
        {
            this.presentationProviders = presentationProviders;
            this.username = username;
        }

        public void Update(List<BuildDetail> buildsDetails)
        {
            foreach (var provider in this.presentationProviders)
            {
                provider.Update(buildsDetails, username); 
            }            
        }

        public void UpdatePRCount(int prCount)
        {
            foreach (var provider in this.presentationProviders)
            {
                provider.UpdatePRCount(prCount);
            }
        }

        public void MarkAsInconclusive()
        {
            foreach (var provider in this.presentationProviders)
            {
                provider.MarkAsInconclusive();
            }
        }
    }
}