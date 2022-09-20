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
    public partial class CreacionUnidades : ContentPage
    {
        private string url = "https://desfrlopez.me/rdiaz/api/unidad_medida/";

        public CreacionUnidades()
        {
            InitializeComponent();
        }

        private async Task CrearUnidadesAsync()
        {
            using (var httpClient = new HttpClient())
            {

                UnidadMedida x = new UnidadMedida()
                {
                    Nombre = f_und_medida.Text,
                    Abrev = f_abrev.Text,

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

                f_und_medida.Text = "";
                f_abrev.Text = "";


            }
        }

        private void CrearUnidad(object sender, EventArgs e)
        {
            _ = CrearUnidadesAsync();
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{

        //}

        private async Task BorrarRecetasAsync()
        {
            using (var httpClient = new HttpClient())
            {

                url += f_idun.Text; // mandamos de parametro de url del id a modificar

                var response = await httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    UnidadMedida contenido = JsonConvert.DeserializeObject<UnidadMedida>(content);

                    resultado.Text = "Unidad Borrada: id = " + contenido.Idunidad + " nombre = " + contenido.Nombre;
                }
                else
                {
                    resultado.Text = "Borrado Fallido";
                }

                f_idun.Text = "";


            }
        }

        private void Btn_Borrar(object sender, EventArgs e)
        {
            _ = BorrarRecetasAsync();
        }

        private void Ver_Lista(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListadoUnidades());
        }
    }
}