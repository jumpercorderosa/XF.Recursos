using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Recursos.Browse
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowseView : ContentPage
    {
        public BrowseView()
        {
            InitializeComponent();
        }

        void backButtonClicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
            else
            {
                this.Navigation.PopAsync();
            }
        }

        void forwardButtonClicked(object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

        private void GoInternet(object sender, EventArgs e)
        {
            if (!txtURI.Text.StartsWith("http"))
                txtURI.Text = string.Format("http://{0}", txtURI.Text);

            webView.Source = txtURI.Text;
        }
    }
}