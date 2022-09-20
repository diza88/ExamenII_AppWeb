using ConexionBD_Xamarin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConexionBD_Xamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void irUnidad(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreacionUnidades());
        }

        private void irTelefono(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreacionTelefono());
        }

        private void irReceta(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreacionReceta());
        }

        private void irProveedor(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreacionProveedor());
        }

        private void irIngrediente(object sender, EventArgs e)
        {
            Navigation.PushAsync(new P_Ingrediente());
        }

        private void irPlato(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreacionPlatoComida());
        }
    }
}
