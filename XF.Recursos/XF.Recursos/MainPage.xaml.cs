using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF.Recursos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSimples_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Estilo.SimplesPage());
        }

        private async void btnGlobal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Estilo.GeralView());
        }

        private async void btnDinamico_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Estilo.DinamicoView());
        }

        private async void btnTriggers_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Estilo.TriggersView());
        }

        private async void btnTemplate_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Theme.ThemeView());
        }

        private async void btnHome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PassParameter.HomeView(DateTime.Now.ToString("u")));
        }

        private async void btnMC_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PassParameter.MCHomeView());
        }

        private async void btnMestre_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu.MainPage());
        }

        private async void btnListSimples_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lista.SimplesView());
        }

        private async void btnListClasse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lista.ClasseView());
        }

        private async void btnProduto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lista.ProdutoView());
        }

        private async void btnEtiqueta_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lista.ListaEtiquetaView());
        }

        private async void btnLocation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GPS.CoordenadaView());
        }
    }
}
