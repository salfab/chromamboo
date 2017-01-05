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

        private static IPresentationService presentationService;

        private static void Main(string[] args)
        {
            string username = null;
            string password = null;
            if (args.Length <= 1)
            {
                Console.Write(
                    "Chromamboo bambooApiBaseUrl bitbucketApiBaseUrl presentationProviderName gitNotificationProviderName [username] [password]");
                return;
            }

            var bambooApiBaseUrl = args[0];
            var bitbucketApiBaseUrl = args[1];
            var presentationProviderName = args[2];
            var gitNotificationProviderName = args[3];

            if (args.Length > 5)
            {
                username = args[4];
                password = args[5];
            }

            bambooApi = new BambooApi(bambooApiBaseUrl, username, password);
            bitbucketApi = new BitbucketApi(bitbucketApiBaseUrl, "MYV", "metis", username, password);

            // retrieve a list of possible providers from the Command line arguments
            var presentationProviderNames = new[] { presentationProviderName };
            var gitNotificationProviderNames = new[] { gitNotificationProviderName };

            // find all implementations of the presentation provider names
            presentationService = new PresentationService(username, GetProviders(presentationProviderNames));

            // Handle pull requests
            var pullRequestsNotificationProvider = new PullRequestsNotificationProvider(
                bitbucketApi,
                presentationService);
            pullRequestsNotificationProvider.Register();

            // Handle Build Status
            var buildStatusNotificationProvider = new AtlassianCiSuiteBuildStatusNotificationProvider(
                bitbucketApi,
                bambooApi,
                presentationService);
            buildStatusNotificationProvider.Register("MYV-MCI");

            // Handle git ahead/behind notification.
            var gitBehindNotificationProvider = new GitNotificationProvider(GetGitNotificationProviders(gitNotificationProviderNames));
            gitBehindNotificationProvider.Register(@"C:/sources/metis");

            // TODO: get a push notification from the bamboo server whenever a new build is in.
            Console.WriteLine("Hit any key to exit...");
            Console.ReadKey();
        }

        private static IPresentationProvider[] GetProviders(string[] presentationProviderNames)
        {
            // TODO: don't hardcode it.
            return new IPresentationProvider[] { new BlyncPresentationProvider(new BlynclightController()) };
        }

        private static IGitNotificationPresentationProvider[] GetGitNotificationProviders(string[] gitNotificationPresentationProviderNames)
        {
            // TODO: don't hardcode it.
            return new IGitNotificationPresentationProvider[] { };
        }
    }
}
