using System;

using Chromamboo.Contracts;
using Chromamboo.Providers.Presentation;
using Chromamboo.Providers.Presentation.Contracts;
using Ninject;
using Ninject.Extensions.Conventions;

using System.Linq;

namespace Chromamboo
{


    public class Program
    {
        private static IBambooApi bambooApi;

        private static IBitbucketApi bitbucketApi;

       // private static IPresentationService presentationService;

        private static void Main(string[] args)
        {
            var kernel = BuildKernel();
            var bootstrapper = kernel.Get<IBoostrapper>();
            bootstrapper.Start();            
            // TODO: get a push notification from the bamboo server whenever a new build is in.
            Console.WriteLine("Hit any key to exit...");
            Console.ReadKey();
        }

        private static IKernel BuildKernel()
        {
            var kernel = new StandardKernel();


            kernel.Bind(x =>
                x.FromThisAssembly()
                    .IncludingNonePublicTypes()
                    .SelectAllClasses()
                    .Where(type => type.GetInterfaces().Length == 1)
                    .BindSelection((type, types) => type.GetInterfaces().Take(1)));

            return kernel;
        }

        private static IGitNotificationPresentationProvider[] GetGitNotificationProviders(string[] gitNotificationPresentationProviderNames)
        {
            // TODO: don't hardcode it.
            return new IGitNotificationPresentationProvider[]
                    {
                        new RazerChromaGitNotificationPresentationProvider(),
                        new BlyncGitNotificationPresentationProvider()
                    }
                    .Where(provider => gitNotificationPresentationProviderNames.Any(n => n.Equals(provider.Name, StringComparison.OrdinalIgnoreCase)))
                    .ToArray();
        }
    }
}
