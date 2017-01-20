using System;
using System.Collections.Generic;
using System.Linq;
using Blynclight;

namespace Chromamboo.Providers.Presentation
{
    public class BlyncBuildResultPresentationProvider : IBuildResultPresentationProvider
    {
        private readonly BlynclightController blynclightController;

        private readonly int selectedBlyncDevice;
        private readonly string username;

        public BlyncBuildResultPresentationProvider(
            BlynclightController blynclightController, string username, int selectedBlyncDevice = 0)
        {
            this.blynclightController = blynclightController;
            this.username = username;
            this.selectedBlyncDevice = selectedBlyncDevice;
            this.blynclightController.InitBlyncDevices();
        }

        public void UpdateBuildResults(List<BuildDetail> buildsDetails, string username1)
        {
            var buildBrokenByAny = buildsDetails.Where(b => !b.Successful && b.AuthorName != this.username).ToArray();
            var isAnyBroken = buildBrokenByAny.Any();

            var buildBrokenByMe = buildsDetails.Where(b => !b.Successful && b.AuthorName == this.username).ToArray();
            var isMineBroken = buildBrokenByMe.Any();

            var buildDevelopBroken = buildsDetails.Where(b => !b.Successful && b.BranchName == "develop").ToArray();
            var isDevelopBroken = buildDevelopBroken.Any();

            if (isMineBroken)
            {
                this.blynclightController.TurnOnYellowLight(this.selectedBlyncDevice);
                Console.WriteLine($"{DateTime.Now} {string.Join(",", buildBrokenByMe.Select(s => s.AuthorName))} broke {string.Join(",", buildBrokenByMe.Select(s => s.BranchName))}");
            }

            if (isDevelopBroken)
            {
                this.blynclightController.TurnOnRedLight(this.selectedBlyncDevice);
                Console.WriteLine($"{DateTime.Now} {string.Join(",", buildDevelopBroken.Select(s => s.AuthorName))} broke {string.Join(",", buildDevelopBroken.Select(s => s.BranchName))}");
            }

            if (isAnyBroken && !isMineBroken && !isDevelopBroken)
            {
                this.blynclightController.TurnOnBlueLight(this.selectedBlyncDevice);
                Console.WriteLine($"{DateTime.Now} {string.Join(",", buildBrokenByAny.Select(s => s.AuthorName))} broke {string.Join(",", buildBrokenByAny.Select(s => s.BranchName))}");
            }

            if (!isMineBroken && !isDevelopBroken && !isAnyBroken)
            {
                this.blynclightController.TurnOnGreenLight(this.selectedBlyncDevice);
                Console.WriteLine($"{DateTime.Now} You guys are the best.");
            }
        }

        public void MarkAsInconclusive()
        {
            // do nothing yet
        }

        public string Name => "blync-build";
    }
}