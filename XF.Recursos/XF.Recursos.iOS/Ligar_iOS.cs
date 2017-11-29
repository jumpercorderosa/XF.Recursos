using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XF.Recursos.iOS;
using XF.Recursos.API;

[assembly: Dependency(typeof(Ligar_iOS))]
namespace XF.Recursos.iOS
{
    public class Ligar_iOS : ILigar
    {
        public bool Discar(string telefone)
        {
            return UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + telefone));
        }
    }
}
