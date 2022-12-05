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
        public static string conexion = "Data Source=DESKTOP-PND4PUV;Initial Catalog=master;Integrated Security=True";
        //public static string conexion = "Data Source=JOSEFATMH;Initial Catalog=master;Integrated Security=True";
        //public static string conexion = "Data Source=DESKTOP-B455DAN;Initial Catalog=master;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        [WebMethod]

        public static string cargarmsg(string Destinatario)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<mensajes> mensaje = new List<mensajes>();


            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "select Fmsg,msg,Remitente,Destinatario from appdblibro.dbo.mensajes where (Remitente = " + HttpContext.Current.Session["IdUser"] + " and Destinatario =" + Destinatario + ") OR (Remitente = " + Destinatario + " and Destinatario =" + HttpContext.Current.Session["IdUser"] + ") ORDER BY Fmsg ASC;";
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
            string jsonString = js.Serialize(mensaje);
            return jsonString;
        }

        [WebMethod]

        public static void agregarmensaje(string Destinatario, string msg)
        {

            using (SqlConnection connection = new SqlConnection(conexion))
            {

                String sql = "INSERT INTO appdblibro.dbo.mensajes(Remitente, Destinatario,msg,Fmsg) VALUES ('" + HttpContext.Current.Session["IdUser"] + "',' " + Destinatario + "', '" + msg + "',GETDATE())";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                    }
                }
            }

        }

        [WebMethod]
        public static string cargarperfiles()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Perfil> perfs = new List<Perfil>();
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                //String sql2 = "SELECT p.Usuario,p.IDPerfil FROM appdblibro.dbo.perfil as p INNER JOIN (SELECT DISTINCT m.Destinatario FROM appdblibro.dbo.mensajes as m WHERE m.Remitente = " + HttpContext.Current.Session["IdUser"] + " ) q ON p.IDPerfil = q.Destinatario";
                String sql2 = "SELECT p.Usuario,p.IDPerfil FROM appdblibro.dbo.perfil as p INNER JOIN (SELECT seguido,seguidor FROM appdblibro.dbo.seguidores where seguidor=" + HttpContext.Current.Session["IdUser"] + " ) q ON p.IDPerfil = q.seguido ";

                using (SqlCommand command = new SqlCommand(sql2, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())

                        {

                            perfs.Add(new Perfil()
                            {
                                Usuario = reader[0].ToString(),
                                IDPerfil = reader[1].ToString(),
                            }
                            );


                        }
                    }

                }

            }
            string jsonString = js.Serialize(perfs);
            return jsonString;
        }
    }
}