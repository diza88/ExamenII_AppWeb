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
    public partial class CreacionProveedor : ContentPage
    {
        private string url = "https://desfrlopez.me/rdiaz/api/proveedor/";
        public CreacionProveedor()
        {
            InitializeComponent();
        }

        private async Task CrearProveedoresAsync()
        {
            using (var httpClient = new HttpClient())
            {

                Proveedor x = new Proveedor()
                {
                    Nombre = f_proveedor.Text,
                    Correo = f_correo.Text,

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
                f_correo.Text = "";


            }
        }

        private void CrearProveedor(object sender, EventArgs e)
        {
            _ = CrearProveedoresAsync();
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{

        //}

        private async Task BorrarProveedorAsync()
        {
            using (var httpClient = new HttpClient())
            {

                url += f_idpv.Text; // mandamos de parametro de url del id a modificar

                var response = await httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    Proveedor contenido = JsonConvert.DeserializeObject<Proveedor>(content);

                    resultado.Text = "Proveedor Borrado: id = " + contenido.Idproveedor + " nombre = " + contenido.Nombre;
                }
                else
                {
                    resultado.Text = "Borrado Fallido";
                }

                f_idpv.Text = "";


            }
        }

        private void Btn_Borrar(object sender, EventArgs e)
        {
            _ = BorrarProveedorAsync();
        }

        private void Ver_Lista(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListadoProveedores());
        }
    }
}