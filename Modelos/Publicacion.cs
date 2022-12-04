using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLibrosDB.Modelos
{
    public class Publicacion
    {
        public string IDPerfil { get; set; }
        public string IDPublicacion { get; set; }
        public string Titulo { get; set; }
        public string Cuerpo { get; set; }

        public string FechaPublicacion { get; set; }

        public string Rating { get; set; }
        public string NombrePerfil { get; set; }

    }
}