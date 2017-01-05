using System.Diagnostics;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using LibGit2Sharp;

namespace Chromamboo.Providers.Presentation
{
    public class RazerChromaGitNotificationPresentationProvider : IGitNotificationPresentationProvider
    {
        public void UpdateGitNotification(HistoryDivergence divergenceWithDevelop, HistoryDivergence divergenceWithRemote)
        {

            if (divergenceWithDevelop.BehindBy > 0)
            {
                Debug.WriteLine("Behind origin/develop by: {0}", divergenceWithDevelop.BehindBy);
                Chroma.Instance.Keyboard.SetKeys(new Color(0.0, 0.0, 1.0), Key.Macro2);
            }
            else
            {
                Chroma.Instance.Keyboard.SetKeys(new Color(120, 200 , 240), Key.Macro2);
            }

            if (divergenceWithRemote.AheadBy > 0)
            {
                Debug.WriteLine("unpushed commits: {0}", divergenceWithRemote.AheadBy);
                Chroma.Instance.Keyboard.SetKeys(new Color(1.0, 0.0, 1.0), Key.Macro3);
            }
            else
            {
                Chroma.Instance.Keyboard.SetKeys(new Color(120, 200, 240), Key.Macro3);
            }
        }
    }
}