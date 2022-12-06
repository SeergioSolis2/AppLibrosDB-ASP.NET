using System;
using System.Collections.Generic;
using System.Data;
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
        public static void EliminarLibro(int id)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = " Delete from appdblibro.dbo.libros where ISBN=" + id + " ";
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
        public static void InsertLibro(int isbn,string autor,string titulo,string edicion,string editorial,string lugar,int año,int paginas,int rating)
        {


            using (SqlConnection connection = new SqlConnection(conexion))
            {



                //String sql = "SELECT Usuario,Contrasena FROM appdblibros.perfil where Usuario='" + Username + "' and Contrasena='" + password + "'";
                String sql = "INSERT INTO appdblibro.dbo.libros (ISBN,Autor,Titulo,Edicion,Editorial,Lugar,Anio,Paginas,Rating) values("+isbn+ ",'" + autor + "','" + titulo + "','" + edicion + "','" + editorial + "','" + lugar + "'," + año + "," + paginas + "," + rating + ")";
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


        [WebMethod]
        public static string Getlibros()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Libro> Libro = new List<Libro>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "select ISBN,Autor,Titulo,Edicion,Editorial,Lugar,Anio,Paginas,Rating from appdblibro.dbo.libros order by ISBN";
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




        [WebMethod]
        public static string Reporte1()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Reportes> Reporte = new List<Reportes>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "appdblibro.dbo.SP_Reporteslibros";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@kind", SqlDbType.Int).Value = 1;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Reporte.Add(new Reportes()
                            {
                                Fila1 = reader[0].ToString(),
                                Fila2 = reader[1].ToString(),
                                Fila3 = reader[2].ToString(),

                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Reporte);
            return jsonString;
        }



        [WebMethod]
        public static string Reporte2()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Reportes> Reporte = new List<Reportes>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {
      


             String sql = "appdblibro.dbo.SP_Reporteslibros";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@kind", SqlDbType.Int).Value = 2;
                    connection.Open();
                  
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Reporte.Add(new Reportes()
                            {
                                Fila1 = reader[0].ToString(),
                                Fila2 = reader[1].ToString(),
                                Fila3 = reader[2].ToString(),

                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Reporte);
            return jsonString;
        }



        [WebMethod]
        public static string Reporte3()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Reportes> Reporte = new List<Reportes>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "appdblibro.dbo.SP_Reporteslibros";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@kind", SqlDbType.Int).Value = 3;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Reporte.Add(new Reportes()
                            {
                                Fila1 = reader[0].ToString(),
                                Fila2 = reader[1].ToString(),
                               

                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Reporte);
            return jsonString;
        }




        [WebMethod]
        public static string Reporte4()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Reportes> Reporte = new List<Reportes>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "appdblibro.dbo.SP_Reporteslibros";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@kind", SqlDbType.Int).Value = 4;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Reporte.Add(new Reportes()
                            {
                                Fila1 = reader[0].ToString(),
                                Fila2 = reader[1].ToString(),
                               

                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Reporte);
            return jsonString;
        }



        [WebMethod]
        public static string Reporte5()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Reportes> Reporte = new List<Reportes>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "appdblibro.dbo.SP_Reporteslibros";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@kind", SqlDbType.Int).Value = 5;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Reporte.Add(new Reportes()
                            {
                                Fila1 = reader[0].ToString(),
                                Fila2 = reader[1].ToString(),


                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Reporte);
            return jsonString;
        }


        [WebMethod]
        public static string Reporte6()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Reportes> Reporte = new List<Reportes>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "appdblibro.dbo.SP_Reporteslibros";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@kind", SqlDbType.Int).Value = 6;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Reporte.Add(new Reportes()
                            {
                                Fila1 = reader[0].ToString(),
                                Fila2 = reader[1].ToString(),
                                Fila3 = reader[2].ToString(),


                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Reporte);
            return jsonString;
        }

        [WebMethod]
        public static string Reporte7()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Reportes> Reporte = new List<Reportes>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "appdblibro.dbo.SP_Reporteslibros";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@kind", SqlDbType.Int).Value = 7;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Reporte.Add(new Reportes()
                            {
                                Fila1 = reader[0].ToString(),
                                Fila2 = reader[1].ToString(),
                              


                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Reporte);
            return jsonString;
        }

        [WebMethod]
        public static string Reporte8()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Reportes> Reporte = new List<Reportes>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "appdblibro.dbo.SP_Reporteslibros";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@kind", SqlDbType.Int).Value = 8;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Reporte.Add(new Reportes()
                            {
                                Fila1 = reader[0].ToString(),
                                Fila2 = reader[1].ToString(),



                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Reporte);
            return jsonString;
        }




        [WebMethod]
        public static string Reporte9()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Reportes> Reporte = new List<Reportes>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "appdblibro.dbo.SP_Reporteslibros";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@kind", SqlDbType.Int).Value = 9;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Reporte.Add(new Reportes()
                            {
                                Fila1 = reader[0].ToString(),
                                Fila2 = reader[1].ToString(),



                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Reporte);
            return jsonString;
        }



        [WebMethod]
        public static string ReporteFinal()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Reportes> Reporte = new List<Reportes>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "appdblibro.dbo.SP_Reporteslibros";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@kind", SqlDbType.Int).Value = 10;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Reporte.Add(new Reportes()
                            {
                                Fila1 = reader[0].ToString(),
                                Fila2 = reader[1].ToString(),



                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Reporte);
            return jsonString;
        }

        [WebMethod]
        public static string GetUsuarios()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Reportes> Reporte = new List<Reportes>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "appdblibro.dbo.SP_Reporteslibros";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@kind", SqlDbType.Int).Value = 11;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Reporte.Add(new Reportes()
                            {
                                Fila1 = reader[0].ToString(),
                                Fila2 = reader[1].ToString(),
                                Fila3 = reader[2].ToString(),



                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Reporte);
            return jsonString;
        }

    }
}


   
