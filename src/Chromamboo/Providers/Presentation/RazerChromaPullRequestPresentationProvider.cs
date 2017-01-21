using Chromamboo.Providers.Presentation.Contracts;

using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;

namespace Chromamboo.Providers.Presentation
{
    public class RazerChromaPullRequestPresentationProvider : IPullRequestPresentationProvider
    {
      
        public void UpdatePullRequestCount(int pullRequestCount)
        {
            Color color;
            if (pullRequestCount == 0)
            {
                color = new Color(0.0, 1.0, 0.0);
            }
            else if (pullRequestCount < 3)
            {
                color = new Color(255, 47, 0);
            }
            else
            {
                color = new Color(1, 0.0, 0.0);
            }

            Chroma.Instance.Keyboard.SetKey(Key.Macro1, color);
        }

        public void MarkAsInconclusive()
        {
            Chroma.Instance.Keyboard.SetKey(Key.Macro1, Color.Purple);
        }

        public string Name => "RazerChroma-PullRequest";
    }
}