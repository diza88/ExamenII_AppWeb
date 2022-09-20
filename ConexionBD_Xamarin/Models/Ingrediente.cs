using System;
using System.Collections.Generic;
using System.Text;

namespace ConexionBD_Xamarin.Models
{
    
    internal class Ingrediente
    {
        public string Idingrediente { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Idproveedor { get; set; }
        

        internal string toJson()
        {
            return "{\"idingrediente\":\"" + Idingrediente + " \", \"nombre\":\"" + Nombre + " \",\"precio\": \"" + Precio + "\", \"idproveedor\": \"" + Idproveedor + "\" }";
        }


    }
}
