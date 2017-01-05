using System;

namespace Chromamboo.Providers.Presentation
{
    using System.Collections.Generic;
    using System.Linq;

    using Corale.Colore.Core;
    using Corale.Colore.Razer.Keyboard;

    using Notification;

    public class RazerChromaPresentationProvider : IPresentationProvider
    {
        private const Key KeysForAllBuilds = Key.Logo;

        private readonly Key[] keysForMyBuilds = new[]
        {
            Key.Num0,
            Key.NumDecimal,
            Key.NumEnter,
            Key.Num1,
            Key.Num2,
            Key.Num3,
            Key.Num4,
            Key.Num5,
            Key.Num6,
            Key.Num7,
            Key.Num8,
            Key.Num9,
            Key.NumLock,
            Key.NumDivide,
            Key.NumMultiply,
            Key.NumSubtract,
            Key.NumAdd
        };

        public void Update(List<BuildDetail> buildsDetails, string username)
        {
            // TODO : resolve with either MEF, or Ninject discovery some modules the presentation service can use, and call a common contract. 
            // Then, move the following code to one of these modules dedicated to Razer keyboard support. Other extensions can then be developed. (blync, for instance)
            var isAnyBroken = buildsDetails.Any(b => !b.Successful);

            var isMineBroken = buildsDetails.Any(b => !b.Successful && b.AuthorName == username);

            Chroma.Instance.Keyboard.SetKeys(
                this.keysForMyBuilds,
                isMineBroken ? new Color(1.0, 0.0, 0.0) : new Color(0.0, 1.0, 0.0));

            Chroma.Instance.Keyboard.SetKey(
                KeysForAllBuilds,
                isAnyBroken ? new Color(1.0, 0.0, 0.0) : new Color(0.0, 1.0, 0.0));
        }

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

        public void MarkAsInconclusive(AtlassianCiSuiteBuildStatusNotificationProvider.NotificationType notificationType)
        {
            switch (notificationType)
            {
                case AtlassianCiSuiteBuildStatusNotificationProvider.NotificationType.Build:
                    Chroma.Instance.Keyboard.SetKeys(this.keysForMyBuilds, new Color(0.5, 0.0, 0.5));
                    Chroma.Instance.Keyboard.SetKey(KeysForAllBuilds, new Color(0.5, 0.0, 0.5));
                    break;
                case AtlassianCiSuiteBuildStatusNotificationProvider.NotificationType.PullRequest:
                    Chroma.Instance.Keyboard.SetKey(Key.Macro1, Color.Purple);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(notificationType), notificationType, null);
            }
        }
    }
}