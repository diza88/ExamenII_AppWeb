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
    public partial class CreacionReceta : ContentPage
    {
        private string url = "https://desfrlopez.me/rdiaz/api/receta/";
        public CreacionReceta()
        {
            InitializeComponent();
        }

        private async Task CrearRecetasAsync()
        {
            using (var httpClient = new HttpClient())
            {

                Receta x = new Receta()
                {
                    Idplato = f_plato.Text,
                    Idingrediente = f_ingrediente.Text,
                    Cantidad = double.Parse(f_cantidad.Text),
                    Idunidad = f_ingrediente.Text,

                };



                var body = x.toJson();
                HttpContent c = new StringContent((string)body, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Insercion Exitosa";
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                f_plato.Text = "";
                f_ingrediente.Text = "";
                f_cantidad.Text = "";
                f_medida.Text = "";


            }
        }

        private void CrearReceta(object sender, EventArgs e)
        {
            _ = CrearRecetasAsync();
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{

        //}

        private async Task BorrarRecetasAsync()
        {
            using (var httpClient = new HttpClient())
            {

                url += f_idr.Text; // mandamos de parametro de url del id a modificar

                var response = await httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    Receta contenido = JsonConvert.DeserializeObject<Receta>(content);

                    resultado.Text = "Receta Borrada: id = " + contenido.Idingrediente + " nombre = " + contenido.Idplato;
                }
                else
                {
                    resultado.Text = "Borrado Fallido";
                }

                f_idr.Text = "";


            }
        }

        private void Btn_Borrar(object sender, EventArgs e)
        {
            _ = BorrarRecetasAsync();
        }

        private void Ver_Lista(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListadoReceta());
        }
    }
}