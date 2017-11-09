using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Recursos.Theme
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemeView : ContentPage
    {
        bool originalTemplate = true;
        ControlTemplate fuchsiaTemplate;
        ControlTemplate maroonTemplate;

        public static readonly BindableProperty HeaderFIAPProperty = 
            BindableProperty.Create("HeaderFIAP", typeof(string), typeof(ThemeView), null);
        public static readonly BindableProperty FooterFIAPProperty = 
            BindableProperty.Create("FooterFIAP", typeof(string), typeof(ThemeView), null);

        public string HeaderFIAP
        {
            get { return (string)GetValue(HeaderFIAPProperty); }
        }

        public string FooterFIAP
        {
            get { return (string)GetValue(FooterFIAPProperty); }
        }

        public ThemeView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            fuchsiaTemplate = (ControlTemplate)Application.Current.Resources["FuchsiaTemplate"];
            maroonTemplate = (ControlTemplate)Application.Current.Resources["MaroonTemplate"];
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            originalTemplate = !originalTemplate;
            contentView.ControlTemplate = (originalTemplate) ? fuchsiaTemplate : maroonTemplate;
        }
    }
}