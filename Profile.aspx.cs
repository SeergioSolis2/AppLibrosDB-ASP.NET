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



                String sql = "SELECT Nombres,Apellido_P,Apellido_M,Usuario FROM appdblibro.dbo.perfil where (Usuario='" + HttpContext.Current.Session["Usuario"] + "' ) or (Email='" + HttpContext.Current.Session["Usuario"] + "') ;";
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
                                Usuario=reader[3].ToString()

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