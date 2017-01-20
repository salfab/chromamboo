using System;

using Chromamboo.Contracts;
using Chromamboo.Providers.Notification;
using Chromamboo.Providers.Presentation;

namespace Chromamboo
{
    using System.Collections.Generic;
    using System.Linq;

    using Blynclight;

    public class Program
    {
        private static IBambooApi bambooApi;

        private static IBitbucketApi bitbucketApi;

       // private static IPresentationService presentationService;

        private static void Main(string[] args)
        {
            string username = null;
            string password = null;
            if (args.Length <= 1)
            {
                Console.Write( "Chromamboo bambooApiBaseUrl bitbucketApiBaseUrl repositoryPath presentationProviderName gitNotificationProviderName [username] [password]");
                return;
            }

            var bambooApiBaseUrl = args[0];
            var bitbucketApiBaseUrl = args[1];
            var repositoryPath = args[2];
            var presentationProviderName = args[3];
            var gitNotificationProviderName = args[4];

            if (args.Length > 6)
            {
                username = args[5];
                password = args[6];
            }

            Console.WriteLine($"bambooApiBaseUrl = {args[0]}");
            Console.WriteLine($"bitbucketApiBaseUrl = {args[1]}");
            Console.WriteLine($"repositoryPath = {args[2]}");
            Console.WriteLine($"presentationProviderName = {args[3]}");
            Console.WriteLine($"gitNotificationProviderName = {args[4]}");

            // TODO: use IoC so that NotificationProviders can be loaded and instantiated from commandline arguments.
            bambooApi = new BambooApi(bambooApiBaseUrl, username, password);
            bitbucketApi = new BitbucketApi(bitbucketApiBaseUrl, "MYV", "metis", username, password);

            // retrieve a list of possible providers from the Command line arguments
            var presentationProviderNames = new[] { presentationProviderName };
            var gitNotificationProviderNames = new[] { gitNotificationProviderName };

            // find all implementations of the presentation provider names
            //presentationService = new PresentationService(username, GetProviders(presentationProviderNames));

            // Handle pull requests
            var pullRequestsNotificationProvider = new PullRequestsNotificationProvider(
                bitbucketApi,
                new PollingNotificationTrigger(),
                // TODO: build array based on presentationProviderNames
                new RazerChromaPullRequestPresentationProvider());
            pullRequestsNotificationProvider.Register();

            // Handle Build Status
            var buildStatusNotificationProvider = new AtlassianCiSuiteBuildStatusNotificationProvider(
                username,
                bitbucketApi,
                bambooApi,
                // TODO: build array based on presentationProviderNames 
                new RazerChromaBuildResultPresentationProvider());
            buildStatusNotificationProvider.Register("MET-MCI");

            // Handle git ahead/behind notification.
            var gitBehindNotificationProvider = new GitNotificationProvider(GetGitNotificationProviders(gitNotificationProviderNames));
            gitBehindNotificationProvider.Register(repositoryPath);

            // TODO: get a push notification from the bamboo server whenever a new build is in.
            Console.WriteLine("Hit any key to exit...");
            Console.ReadKey();
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
