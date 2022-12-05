using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLibrosDB.Modelos
{
    public class Libro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }


        public string Autor { get; set; }
        public string Edicion { get; set; }
        
        public string  Editorial { get; set; }
        public string Lugar{ get; set; }
        public string Anio{ get; set; }
        public string Paginas{ get; set; }

        public string Rating{ get; set; }
    }
}