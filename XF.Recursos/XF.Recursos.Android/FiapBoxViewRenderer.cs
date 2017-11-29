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
using XF.Recursos.CustomControl;
using XF.Recursos.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using System.ComponentModel;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FiapBoxView), typeof(FiapBoxViewRenderer))]
namespace XF.Recursos.Droid
{
    public class FiapBoxViewRenderer : BoxRenderer
    {
        public FiapBoxViewRenderer()
        {
            //nao vai desenhar oq esta no controle pq vamos reencrever o Draw que vai ser renderizado na tela
            SetWillNotDraw(false);
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            FiapBoxView boxView = (FiapBoxView)Element;

            Rect ret = new Rect();
            GetDrawingRect(ret);

            Rect inside = ret;
            inside.Inset((int)boxView.EspessuraDaBorda, (int)boxView.EspessuraDaBorda);

            Paint paint = new Paint();
            paint.Color = boxView.Color.ToAndroid();

            canvas.DrawRect(inside, paint);
            paint.Color = boxView.CorDaBorda.ToAndroid();
            paint.StrokeWidth = (float)boxView.EspessuraDaBorda;
            paint.SetStyle(Paint.Style.Stroke);

            canvas.DrawRect(ret, paint);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            Invalidate();
        }
    }
}