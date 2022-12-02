using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppLibrosDB.Modelos
{
    public class mensajes
    {
         public string Remitente { get; set; }
         public string Destinatario { get; set; }
         public string msg { get; set; }
         public string Fmsg { get; set; }
    }
    
}