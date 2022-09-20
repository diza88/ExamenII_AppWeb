using System;
using System.Collections.Generic;
using System.Text;

namespace ConexionBD_Xamarin.Models
{
    internal class Receta
    {
        public string Idreceta { get; set; }
        public string Idplato { get; set; }
        public string Idingrediente { get; set; }
        public double Cantidad { get; set; }
        public string Idunidad { get; set; }

        internal object toJson()
        {
            return "{\"idplato\":\"" + Idplato + " \",\"idingrediente\": \"" + Idingrediente + "\",\"cantidad\": \"" + Cantidad + "\",\"idunidad\": \"" + Idunidad + "\" }";
        }
    }
}
