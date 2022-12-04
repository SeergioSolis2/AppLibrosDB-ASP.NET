using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLibrosDB.Modelos
{
    public class Comentarios
    {
        public string IDPublicacion { get; set; }
        public string IDPerfil { get; set; }
        public string Comentario { get; set; }
        public string Fecha_Comentario { get; set; }

        public string Nombre { get; set; }

        public string IDComentario { get; set; }
    }
}