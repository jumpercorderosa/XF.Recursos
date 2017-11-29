using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using XF.Recursos.CustomControl;
using XF.Recursos.Droid;
using Xamarin.Forms.Platform.Android;

//substitui o fiap button pelo fiap renderer
[assembly: ExportRenderer(typeof(FiapButton), typeof(FiapButtonRenderer))]
namespace XF.Recursos.Droid
{
    class FiapButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //vamos utilizar uma cor que não existe no xamarin forms
                Control.SetBackgroundColor(Android.Graphics.Color.Gray);
            }
        }
    }
}
