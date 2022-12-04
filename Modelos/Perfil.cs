using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLibrosDB.Modelos
{
    public class Perfil
    {
        public string Usuario { get; set; }
        public string Password { get; set; }

        public string IDPerfil { get; set; }
        public string Nombres { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }

        public string Email { get; set; }

        public string FechaNacimiento { get; set; }

        public string FechaRegistro { get; set; }

        public string Followers { get; set; }

        public string Followings { get; set; }

        public string Rep { get; set; }


    }
}