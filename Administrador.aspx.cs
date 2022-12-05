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
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static string conexion = "Data Source=DESKTOP-PND4PUV;Initial Catalog=master;Integrated Security=True";

        [WebMethod]
        public static string Getlibros()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Libro> Libro = new List<Libro>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "select ISBN,Autor,Titulo,Edicion,Editorial,Lugar,Anio,Paginas,Rating from appdblibro.dbo.libros";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Libro.Add(new Libro()
                            {
                                ISBN = reader[0].ToString(),
                                Autor = reader[1].ToString(),
                                Titulo = reader[2].ToString(),
                                Edicion = reader[3].ToString(),
                                Editorial = reader[4].ToString(),
                                Lugar = reader[5].ToString(),
                                Anio = reader[6].ToString(),
                                Paginas = reader[7].ToString(),
                                Rating = reader[8].ToString(),
                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Libro);
            return jsonString;
        }
    }
}