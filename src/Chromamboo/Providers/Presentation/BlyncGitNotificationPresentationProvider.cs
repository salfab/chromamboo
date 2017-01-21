using Chromamboo.Providers.Presentation.Contracts;
using LibGit2Sharp;

namespace Chromamboo.Providers.Presentation
{
    using System;

    public class BlyncGitNotificationPresentationProvider : IGitNotificationPresentationProvider
    {
        public void UpdateGitNotification(
            HistoryDivergence divergenceWithDevelop, 
            HistoryDivergence divergenceWithRemote)
        {
            if (divergenceWithDevelop.BehindBy > 0)
            {
                Console.WriteLine($"{DateTime.Now} Behind origin/develop by: {divergenceWithDevelop.BehindBy}");
            }
            else
            {
            }

            if (divergenceWithRemote.AheadBy > 0)
            {
                Console.WriteLine($"{DateTime.Now} Unpushed commits: {divergenceWithRemote.AheadBy}");
            }
            else
            {
            }
        }

        public void MarkAsInconclusive()
        {
            throw new NotImplementedException();
        }

        public string Name => "blync";
    }
}