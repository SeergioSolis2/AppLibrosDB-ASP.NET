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

    
    public partial class Buscador : System.Web.UI.Page
    {

        public static string conexion = "Data Source=DESKTOP-PND4PUV;Initial Catalog=master;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string GetUser()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Perfil> Perfil = new List<Perfil>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                //String sql = "SELECT Usuario,Contrasena FROM appdblibros.perfil where Usuario='" + Username + "' and Contrasena='" + password + "'";
                String sql = "SELECT Nombres FROM appdblibro.dbo.perfil ;";
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