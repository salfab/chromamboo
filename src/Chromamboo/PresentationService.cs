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
            //// TODO : resolve with either MEF, or Ninject discovery some modules the presentation service can use, and call a common contract. 
            //// Then, move the following code to one of these modules dedicated to Razer keyboard support. Other extensions can then be developed. (blync, for instance)
            //var isAnyBroken = buildsDetails.Any(b => !b.Successful);

            //var isMineBroken = buildsDetails.Any(b => !b.Successful && b.AuthorName == this.username);
            //var numPad = new[]
            //                 {                                    
            //                     Key.Num0,
            //                     Key.NumDecimal,
            //                     Key.NumEnter,
            //                     Key.Num1,
            //                     Key.Num2,
            //                     Key.Num3,
            //                     Key.Num4,
            //                     Key.Num5,
            //                     Key.Num6,
            //                     Key.Num7,
            //                     Key.Num8,
            //                     Key.Num9,
            //                     Key.NumLock,
            //                     Key.NumDivide,
            //                     Key.NumMultiply,
            //                     Key.NumSubtract,
            //                     Key.NumAdd
            //                 };
            //if (isMineBroken)
            //{
            //    //Chroma.Instance.Keyboard.SetReactive(new Reactive(Color.Purple, Duration.Long));
            //    Chroma.Instance.Keyboard.SetKeys(numPad, new Color(1.0, 0.0, 0.0));
            //}
            //else
            //{
            //    //Chroma.Instance.Keyboard.SetReactive(new Reactive(Color.Purple, Duration.Long));
            //    Chroma.Instance.Keyboard.SetKeys(numPad, new Color(0.0, 1.0, 0.0));
            //}

            //if (isAnyBroken)
            //{
            //    //Chroma.Instance.Keyboard.SetReactive(new Reactive(Color.Purple, Duration.Long));
            //    Chroma.Instance.Keyboard.SetKey(Key.Logo, new Color(1.0, 0.0, 0.0));
            //}
            //else
            //{
            //    //Chroma.Instance.Keyboard.SetReactive(new Reactive(Color.Purple, Duration.Long));
            //    Chroma.Instance.Keyboard.SetKey(Key.Logo, new Color(0.0, 1.0, 0.0));
            //}
        }

        public void UpdatePRCount(int prCount)
        {
            foreach (var provider in this.presentationProviders)
            {
                provider.UpdatePRCount(prCount);
            }
          
        }
    }
}