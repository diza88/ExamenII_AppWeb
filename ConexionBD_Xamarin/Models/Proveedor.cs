using System;
using System.Collections.Generic;
using System.Text;

namespace ConexionBD_Xamarin.Models
{
    internal class Proveedor
    {
        public string Idproveedor { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

        internal object toJson()
        {
            return "{\"nombre\":\"" + Nombre + " \",\"correo\": \"" + Correo + "\" }";
        }
    }
}
