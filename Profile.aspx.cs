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
    public partial class Profile : System.Web.UI.Page
    {
        //Conexion Sergio
        public static string conexion = "Data Source=DESKTOP-PND4PUV;Initial Catalog=master;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        [WebMethod]
        public static string GetPerfil()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Perfil> Perfil = new List<Perfil>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "SELECT Nombres,Apellido_P,Apellido_M,Usuario,Email,IDPerfil,Fnac,CONVERT (char(10), Freg, 103) FROM appdblibro.dbo.perfil where (Usuario='" + HttpContext.Current.Session["Usuario"] + "' ) or (Email='" + HttpContext.Current.Session["Usuario"] + "') ;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                      
                        while (reader.Read())
                        {

                            Perfil.Add(new Perfil()
                            {
                                Nombres = reader[0].ToString(),
                                ApellidoP = reader[1].ToString(),
                                ApellidoM=reader[2].ToString(),
                                Usuario=reader[3].ToString(),
                                Email =reader[4].ToString(),
                                IDPerfil=reader[5].ToString(),
                                FechaNacimiento=reader[6].ToString(),
                                FechaRegistro=reader[7].ToString()
                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Perfil);
            return jsonString;

        }


        [WebMethod]

        public static string ConteoFollowers(int idPerfil)
        {
            string Followers = "";
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Perfil> Perfil = new List<Perfil>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                //String sql = "SELECT Usuario,Contrasena FROM appdblibros.perfil where Usuario='" + Username + "' and Contrasena='" + password + "'";
                String sql = "select COUNT(seguidor) from appdblibro.dbo.seguidores where seguido="+idPerfil+";";
                String sql2 = "select COUNT(seguido) from appdblibro.dbo.seguidores where seguidor = "+idPerfil+ ";";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {


                            Followers = reader[0].ToString();
                               





                        }
                    }
                }
                using (SqlCommand command = new SqlCommand(sql2, connection))
                {
                  
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Perfil.Add(new Perfil()
                            {
                                Followers = Followers,
                                Followings = reader[0].ToString()


                            }
                            ); 




                        }
                    }
                }

            }

            string jsonString = js.Serialize(Perfil);
            return jsonString;
        }




        [WebMethod]

        public static void EditarPerfil(string Nombres,string Apellido_P,string Apellido_M,string Usuario,string Email)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "Update appdblibro.dbo.perfil set Nombres='"+Nombres+"',Apellido_P='"+Apellido_P+"',Apellido_M='"+Apellido_M+"',Usuario='"+Usuario+"',Email='"+Email+"' where IDPerfil=" + HttpContext.Current.Session["IdUser"] + "";
 
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
        public static void cerrarsesion()
        {
            HttpContext.Current.Session["Usuario"] = null;

        }

    }
}