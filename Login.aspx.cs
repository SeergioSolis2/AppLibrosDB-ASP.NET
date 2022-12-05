using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppLibrosDB.Modelos;
namespace AppLibrosDB
{

    
    public partial class Prueba2 : System.Web.UI.Page
    {
        public static string conexion = "Data Source=DESKTOP-PND4PUV;Initial Catalog=master;Integrated Security=True";
     


        protected void Page_Load(object sender, EventArgs e)
        {
            string username = null;
            string IdUser = null;
            Context.Session.Add("Usuario",username);
            Context.Session.Add("IdUser", IdUser);
        }

        [WebMethod]
        public static string Login(string Username, string password)
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Perfil> Perfil = new List<Perfil>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {

         

                //String sql = "SELECT Usuario,Contrasena FROM appdblibros.perfil where Usuario='" + Username + "' and Contrasena='" + password + "'";
                String sql = "SELECT IDPerfil,Usuario,Contrasena FROM appdblibro.dbo.perfil where (Usuario='" + Username + "' and Contrasena=HASHBYTES('MD5','" + password + "')) or (Email='" + Username + "'and Contrasena=HASHBYTES('MD5','" + password + "')) ;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        HttpContext.Current.Session["Usuario"]= Username;
                        while (reader.Read())
                        {
                            HttpContext.Current.Session["IdUser"] = reader[0].ToString();
                            Perfil.Add(new Perfil()
                            {
                                IDPerfil=reader[0].ToString(),
                                Usuario = reader[1].ToString(),
                                Password = reader[2].ToString()
                                
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
        public static void Registro(string Nombres, string Apellido_P, string Apellido_M, string Sexo, string Nacionalidad, string FNac, string Usuario, string Email, string Contrasena)
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Perfil> Perfil = new List<Perfil>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                //String sql = "SELECT Usuario,Contrasena FROM appdblibros.perfil where Usuario='" + Username + "' and Contrasena='" + password + "'";
                String sql = "INSERT INTO appdblibro.dbo.perfil(Nombres, Apellido_P,Apellido_M,Sexo,Nacionalidad,FNac,Usuario,Email,Contrasena,FReg,Rep) VALUES ('"+Nombres+"',' "+Apellido_P+"', '"+Apellido_M+ "', '" + Sexo + "', '" + Nacionalidad + "', '" + FNac + "', '" + Usuario + "', '" + Email + "', HASHBYTES('MD5','" + Contrasena + "'),GETDATE(),0)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    //command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //while (reader.Read())
                        //{
                        //}
                    }
                }
            }

        

        }

       
    }
}
