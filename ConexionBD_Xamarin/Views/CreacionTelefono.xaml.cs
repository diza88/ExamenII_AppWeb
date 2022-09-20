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
    public partial class CreacionTelefono : ContentPage
    {
        private string url = "https://desfrlopez.me/rdiaz/api/telefonos/";
        public CreacionTelefono()
        {
            InitializeComponent();
        }

        private async Task CrearTelefonosAsync()
        {
            using (var httpClient = new HttpClient())
            {

                Telefonos x = new Telefonos()
                {
                    Idproveedor = f_proveedor.Text,
                    Telefono = f_telefono.Text,

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

                f_proveedor.Text = "";
                f_telefono.Text = "";


            }
        }

        private void CrearTelefono(object sender, EventArgs e)
        {
            _ = CrearTelefonosAsync();
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{

        //}

        private async Task BorrarTelefonoAsync()
        {
            using (var httpClient = new HttpClient())
            {

                url += f_idph.Text; // mandamos de parametro de url del id a modificar

                var response = await httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    Telefonos contenido = JsonConvert.DeserializeObject<Telefonos>(content);

                    resultado.Text = "Telefono Borrado: id = " + contenido.Idtelefono + " nombre = " + contenido.Telefono;
                }
                else
                {
                    resultado.Text = "Borrado Fallido";
                }

                f_idph.Text = "";


            }
        }

        private void Btn_Borrar(object sender, EventArgs e)
        {
            _ = BorrarTelefonoAsync();
        }

        private void Ver_Lista(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListadoTelefono());
        }
    }
}