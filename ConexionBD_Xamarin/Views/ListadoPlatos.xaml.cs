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
    public partial class ListadoPlatos : ContentPage
    {
        private string url = "https://desfrlopez.me/rdiaz/api/platocomida/";
        public ListadoPlatos()
        {
            InitializeComponent();
            _ = GetPlato();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _ = GetPlato();
        }

        private async Task GetPlato()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<PlatoComida> contenido = JsonConvert.DeserializeObject<List<PlatoComida>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "Identificador: " + contenido[i].Idplato + "\n Ingrediente: " + contenido[i].Nombre_plato + "\n";

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
