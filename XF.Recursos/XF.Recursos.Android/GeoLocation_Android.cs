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
using XF.Recursos.Droid;
using XF.Recursos.GPS;
using Xamarin.Geolocation;
using System.Threading.Tasks;

[assembly: Dependency(typeof(GeoLocation_Android))]

namespace XF.Recursos.Droid
{
    //o comportamento
    public class GeoLocation_Android : ILocalizacao
    {
        public void GetCoordenada()
        {
            //exemplo de intent
            var context = Forms.Context as Activity;
            var locator = new Geolocator(context) { DesiredAccuracy = 50 };

            locator.GetPositionAsync(timeout: 10000).ContinueWith(t => {
                SetCoordenada(t.Result.Latitude, t.Result.Longitude);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        void SetCoordenada(double paramLatitude, double paramLongitude)
        {
            var coordenada = new Coordenada()
            {
                Latitude = paramLatitude.ToString(),
                Longitude = paramLongitude.ToString()
            };

            MessagingCenter.Send<ILocalizacao, Coordenada>
                (this, "coordenada", coordenada);
        }
    }
}