using ConexionBD_Xamarin.Models;
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
    public partial class EditIngrediente : ContentPage
    {
        private string url = "https://desfrlopez.me/rdiaz/api/ingrediente/";
        public EditIngrediente()
        {
            InitializeComponent();
        }

        private async Task UpdateIngredienteAsync()
        {
            

            using (var httpClient = new HttpClient())
            {

                Ingrediente x = new Ingrediente()
                {
                    Idingrediente = f_iding1.Text,
                    Nombre = f_ingrediente1.Text,
                    Precio = f_precio1.Text,
                    Idproveedor = f_proveedor1.Text
                };
                url += f_iding1.Text; // mandamos de parametro de url del id a modificar
                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado1.Text = "Actualizacion Exitosa!!!!";
                }
                else
                {
                    resultado1.Text = "Actualizacion Fallida";
                }

                f_iding1.Text = "";
                f_ingrediente1.Text = "";
                f_precio1.Text = "";
                f_proveedor1.Text = "";

            }
        }

        private void UpdIngrediente(object sender, EventArgs e)
        {
            _ = UpdateIngredienteAsync();
        }
    }
}