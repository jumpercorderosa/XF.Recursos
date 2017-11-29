using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Recursos.API
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraView : ContentPage
    {
        public CameraView()
        {
            InitializeComponent();
        }

        private void btnCamera_Clicked(object sender, EventArgs e)
        {
            ICamera capturar = DependencyService.Get<ICamera>();
            capturar.CapturarFoto();

            MessagingCenter.Subscribe<ICamera, string>(this, "cameraFoto",
                (objeto, image) =>
                {
                    //Endereço físico da imagem
                    this.imgFoto.Source = ImageSource.FromFile(image);
                });
        }

        private void btnSelecionar_Clicked(object sender, EventArgs e)
        {
            ICamera capturar = DependencyService.Get<ICamera>();
            capturar.SelecionarFoto();

            MessagingCenter.Subscribe<ICamera, string>(this, "cameraFoto",
                (objeto, image) =>
                {
                    this.imgFoto.Source = ImageSource.FromFile(image);
                });
        }
    }
}