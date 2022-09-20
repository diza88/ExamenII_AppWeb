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
    public partial class CreacionPlatoComida : ContentPage
    {
        private string url = "https://desfrlopez.me/rdiaz/api/platocomida/";
        public CreacionPlatoComida()
        {
            InitializeComponent();
        }

        private async Task CrearPlatosAsync()
        {
            using (var httpClient = new HttpClient())
            {

                PlatoComida x = new PlatoComida()
                {
                    Nombre_plato = f_plato.Text,
                    Precio = f_precio.Text,
                    Descuento = f_descuento.Text,

                };



                var body = x.toJson();
                HttpContent c = new StringContent((string)body, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Insercion Exitosa!!!";
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                f_plato.Text = "";
                f_precio.Text = "";
                f_descuento.Text = "";


            }
        }

        private void CrearPlato(object sender, EventArgs e)
        {
            _ = CrearPlatosAsync();
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{

        //}

        private async Task BorrarPlatoAsync()
        {
            using (var httpClient = new HttpClient())
            {

                url += f_idpl.Text; // mandamos de parametro de url del id a modificar

                var response = await httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    PlatoComida contenido = JsonConvert.DeserializeObject<PlatoComida>(content);

                    resultado.Text = "Plato Borrado: id = " + contenido.Idplato + " nombre = " + contenido.Nombre_plato;
                }
                else
                {
                    resultado.Text = "Borrado Fallido";
                }

                f_idpl.Text = "";


            }
        }

        private void Btn_Borrar(object sender, EventArgs e)
        {
            _ = BorrarPlatoAsync();
        }

        private void Ver_Lista(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListadoPlatos());
        }
    }
}