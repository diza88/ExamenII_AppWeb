using System;
using System.Collections.Generic;
using System.Text;

namespace ConexionBD_Xamarin.Models
{
    internal class PlatoComida
    {
        public string Idplato { get; set; }
        public string Nombre_plato { get; set; }
        public string Precio { get; set; }
        public string Descuento { get; set; }

        internal object toJson()
        {
            return "{\"nombre_plato\":\"" + Nombre_plato + " \",\"precio\": \"" + Precio + "\",\"descuento\": \"" + Descuento + "\" }";
        }
    }
}
