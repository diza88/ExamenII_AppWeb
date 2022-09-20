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
    public partial class CreacionIngrediente : ContentPage
    {
        private string url = "https://desfrlopez.me/rdiaz/api/ingrediente/";
        public CreacionIngrediente()
        {
            InitializeComponent();
        }

        private async Task CrearIngredientesAsync()
        {
            using (var httpClient = new HttpClient())
            {

                Ingrediente x = new Ingrediente()
                {
                    Nombre = f_ingrediente.Text,
                    Precio = f_precio.Text,
                    Idproveedor = f_proveedor.Text,

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

                f_ingrediente.Text = "";
                f_precio.Text = "";
                f_proveedor.Text = "";
                     

            }
        }

        private void CrearIngrediente(object sender, EventArgs e)
        {
            _ = CrearIngredientesAsync();
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{

        //}

        private async Task BorrarIngredienteAsync()
        {
            using (var httpClient = new HttpClient())
            {

                url += f_iding.Text; // mandamos de parametro de url del id a modificar

                var response = await httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    Ingrediente contenido = JsonConvert.DeserializeObject<Ingrediente>(content);

                    resultado.Text = "Ingrediente Borrado: id = " + contenido.Idingrediente + " nombre = " + contenido.Nombre;
                }
                else
                {
                    resultado.Text = "Borrado Fallido";
                }

                f_iding.Text = "";


            }
        }

        private void Btn_Borrar(object sender, EventArgs e)
        {
            _ = BorrarIngredienteAsync();
        }

        private void Ver_Ing(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditIngrediente());
        }
    }
}