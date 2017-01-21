using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

using Chromamboo.Apis.AtlassianWrappers;
using Chromamboo.Providers.Presentation.Contracts;

using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;

namespace Chromamboo.Providers.Presentation.RazerChroma
{
    public class RazerChromaBuildResultPresentationProvider : BuildResultPresentationProviderBase, IBuildResultPresentationProvider
    {
        private const Key KeysForAllBuilds = Key.Logo;

        private readonly Key[] keysForMyBuilds = {
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

        public void UpdateBuildResults(List<BuildDetail> buildsDetails, string username)
        {
            var isAnyBroken = IsAnyBroken(buildsDetails);

            var isMineBroken = IsMineBroken(buildsDetails, username);

            Chroma.Instance.Keyboard.SetKeys(
                this.keysForMyBuilds,
                isMineBroken ? new Color(1.0, 0.0, 0.0) : new Color(0.0, 1.0, 0.0));

            Chroma.Instance.Keyboard.SetKey(
                KeysForAllBuilds,
                isAnyBroken ? new Color(1.0, 0.0, 0.0) : new Color(0.0, 1.0, 0.0));
        }

        public void MarkAsInconclusive()
        {
            Chroma.Instance.Keyboard.SetKeys(this.keysForMyBuilds, new Color(0.5, 0.0, 0.5));
            Chroma.Instance.Keyboard.SetKey(KeysForAllBuilds, new Color(0.5, 0.0, 0.5));
        }

        public string Name => "razerchroma";
  
    }
}