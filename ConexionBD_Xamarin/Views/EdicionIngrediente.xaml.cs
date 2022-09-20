using ConexionBD_Xamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConexionBD_Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EdicionIngrediente : ContentPage
    {
        private string url = "https://desfrlopez.me/rdiaz/api/ingrediente/";
        private IList<Ingrediente> Ingredientes { get; set; }

        

        public EdicionIngrediente()
        {
            InitializeComponent();
            _ = GetIngrediente();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ = GetIngrediente();
        }

        private async Task GetIngrediente()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<Ingrediente> contenido = JsonConvert.DeserializeObject<List<Ingrediente>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "Identificador: " + contenido[i].Idingrediente + "\n Ingrediente: " + contenido[i].Nombre + "\n";

                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Paises";
                }




            }
        }

    }
}