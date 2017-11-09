using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Xml.Linq;

namespace XF.Recursos.Lista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProdutoView : ContentPage
    {
        public ProdutoView()
        {
            InitializeComponent();

            LoadProdutos();
        }

        private async void LoadProdutos()
        {
            var httpRequest = new HttpClient();
            var stream = await httpRequest.GetStringAsync("http://www.wopek.com/xml/produtos.xml");

            XElement xmlProduto = XElement.Parse(stream);
            var produtos = new List<Produto>();
            foreach (var item in xmlProduto.Elements("produto"))
            {
                Produto produto = new Produto()
                {
                    Id = int.Parse(item.Attribute("id").Value),
                    Descricao = item.Element("descricao").Value,
                    Categoria = item.Element("categoria").Value,
                    Quantidade = int.Parse(item.Element("quantidade").Value),
                    Preco = decimal.Parse(item.Element("precounitario").Value)
                };
                produtos.Add(produto);
            }
            lstProduto.ItemsSource = produtos;
        }

        private void lstProduto_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelecionado = e.Item as Produto;
            DisplayAlert("Produto selecionado",
                $"Id: {itemSelecionado.Id} - {itemSelecionado.Descricao}", "OK");

            //DisplayAlert("Produto selecionado", 
            //    String.Format("Id: {0} - {1}", itemSelecionado.Id, itemSelecionado.Descricao), "OK");
        }
    }
}