using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppLibrosDB.Modelos;

namespace AppLibrosDB
{
    public partial class Inbox : System.Web.UI.Page
    {
        //public static string conexion = "Data Source=DESKTOP-PND4PUV;Initial Catalog=master;Integrated Security=True";
        public static string conexion = "Data Source=JOSEFATMH;Initial Catalog=master;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]

        public static List<mensajes> cargarmsg(int idPerfil, string Destinatario)
        {


            List<mensajes> mensaje = new List<mensajes>();


            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "select Fmsg,msg,Remitente,Destinatario from appdblibro.dbo.mensajes where Remitente = " + idPerfil + " and Destinatario =" + Destinatario + ";";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            mensaje.Add(new mensajes()
                            {
                                Fmsg = reader[0].ToString(),
                                msg = reader[1].ToString(),
                                Remitente = reader[2].ToString(),
                                Destinatario = reader[3].ToString()
                            }
                            );

                        }
                    }
                }


            }

            
            return mensaje;
        }

        [WebMethod]
        public static List<Perfil> cargarperfiles(int idPerfil)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Perfil> Perfil = new List<Perfil>();
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                String sql2 = "SELECT p.Usuario,p.IDPerfil FROM dbo.perfil as p INNER JOIN (SELECT DISTINCT m.Destinatario FROM dbo.mensajes as m WHERE m.Remitente = " + idPerfil + " ) q ON p.IDPerfil = q.Destinatario";


                using (SqlCommand command = new SqlCommand(sql2, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())

                        {

                            Perfil.Add(new Perfil()
                            {

                                Usuario = reader[0].ToString(),
                                IDPerfil = reader[1].ToString(),



                            }
                            );




                        }
                    }

                }

            }
            return Perfil;
        }
    }
}