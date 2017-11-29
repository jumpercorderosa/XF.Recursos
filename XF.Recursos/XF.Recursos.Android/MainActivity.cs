using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XF.Recursos.API;
using Xamarin.Forms;
using Xamarin.Media;
using Android.Content;

[assembly: Dependency(typeof(XF.Recursos.Droid.MainActivity))]
namespace XF.Recursos.Droid
{
    [Activity(Label = "XF.Recursos", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICamera
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        public void CapturarFoto()
        {
            var context = Forms.Context as Activity;
            var captura = new MediaPicker(context);

            var intent = captura.GetTakePhotoUI(new StoreCameraMediaOptions
            {
                DefaultCamera = CameraDevice.Rear,
                Name = string.Format("foto_{0}.jpg", DateTime.Now.ToString()),
                Directory = "Fiap"
            });
            context.StartActivityForResult(intent, 1);
        }

        public void SelecionarFoto()
        {
            var context = Forms.Context as Activity;
            var captura = new MediaPicker(context);

            var intent = captura.GetPickPhotoUI();
            context.StartActivityForResult(intent, 1);
        }

        //reescrevemos pq queremos pegar a volta da camera com a imagem que tirei ou selecionei
        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Canceled) return;

            var mediaPath = await data.GetMediaFileExtraAsync(Forms.Context);

            //passo o endereço de onde a imagem esta
            MessagingCenter.Send<ICamera, string>(this, "cameraFoto", mediaPath.Path);
        }
    }
}

