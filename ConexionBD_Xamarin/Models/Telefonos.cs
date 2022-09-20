using System;
using System.Collections.Generic;
using System.Text;

namespace ConexionBD_Xamarin.Models
{
    internal class Telefonos
    {
        public string Idtelefono { get; set; }
        public string Idproveedor { get; set; }
        public string Telefono { get; set; }

        internal object toJson()
        {
            return "{\"idproveedor\":\"" + Idproveedor + " \",\"telefono\": \"" + Telefono + "\" }";
        }
    }
}
