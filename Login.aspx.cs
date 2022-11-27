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

    
    public partial class Prueba2 : System.Web.UI.Page
    {
        public static string conexion = "Data Source=DESKTOP-PND4PUV;Initial Catalog=master;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
     
        }

        [WebMethod]
        public static string Login(string Username, string password)
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Perfil> Perfil = new List<Perfil>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                //String sql = "SELECT Usuario,Contrasena FROM appdblibros.perfil where Usuario='" + Username + "' and Contrasena='" + password + "'";
                String sql = "SELECT Usuario,Contrasena FROM appdblibro.dbo.perfil where Usuario='"+Username+"' and Contrasena='"+password+"' ;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            Perfil.Add(new Perfil()
                            {
                                Usuario = reader[0].ToString(),
                                Password = reader[1].ToString()
                            }
                            );
                           
                              
                            

                        }
                    }
                }
            }

            string jsonString = js.Serialize(Perfil);
            return jsonString;

        }
    }
}
