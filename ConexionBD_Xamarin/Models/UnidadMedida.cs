using System;
using System.Collections.Generic;
using System.Text;

namespace ConexionBD_Xamarin.Models
{
    internal class UnidadMedida
    {
        public string Idunidad { get; set; }
        public string Nombre { get; set; }
        public string Abrev { get; set; }

        internal object toJson()
        {
            return "{\"nombre\":\"" + Nombre + " \",\"abreviacion\": \"" + Abrev + "\" }";
        }
    }
}
