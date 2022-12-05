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
            if (Context.Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        [WebMethod]
        public static string Gettuslibros(int id)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Libro> Libro = new List<Libro>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = " select A.ISBN,Autor,Titulo,Edicion,Editorial,Lugar,Anio,Paginas,Rating from appdblibro.dbo.libros A join appdblibro.dbo.leidos B on B.ISBN=A.ISBN where B.IDPerfil=" + id+ "";
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
        public static void Reputacionperfil(int idperfil)
        {
            int promedioreputacion = 0;
            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "Select AVG(rating) from appdblibro.dbo.publicaciones where IDPerfil=" + idperfil+ "";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            promedioreputacion = int.Parse(reader[0].ToString());

                        }
                    }
                }


                sql = "update appdblibro.dbo.perfil set Rep=" + promedioreputacion + " where IDPerfil=" +idperfil + "";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {



                    }
                }
            }
        }


        [WebMethod]
        public static string GetUser()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Perfil> Perfil = new List<Perfil>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                //String sql = "SELECT Usuario,Contrasena FROM appdblibros.perfil where Usuario='" + Username + "' and Contrasena='" + password + "'";
                String sql = "SELECT IDPerfil,Usuario,Email,Nombres,Apellido_M,Apellido_P FROM appdblibro.dbo.perfil ;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            if (HttpContext.Current.Session["IdUser"].ToString()!= reader[0].ToString())
                            {
                                Perfil.Add(new Perfil()
                                {
                                    IDPerfil = reader[0].ToString(),
                                    Usuario = reader[1].ToString(),
                                    Email = reader[2].ToString(),
                                    Nombres = reader[3].ToString(),
                                    ApellidoM = reader[4].ToString(),
                                    ApellidoP = reader[5].ToString()



                                }
                                );
                            }
                           

                        }
                    }
                }
            }

            string jsonString = js.Serialize(Perfil);
            return jsonString;
        }


        [WebMethod]
        public static string GetPerfil(int idperfil)
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Perfil> Perfil = new List<Perfil>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "SELECT Nombres,Apellido_P,Apellido_M,Usuario,Email,IDPerfil,Fnac,CONVERT (char(10), Freg, 103),Rep FROM appdblibro.dbo.perfil where IDPerfil="+idperfil+"  ;";
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
                                ApellidoM = reader[2].ToString(),
                                Usuario = reader[3].ToString(),
                                Email = reader[4].ToString(),
                                IDPerfil = reader[5].ToString(),
                                FechaNacimiento = reader[6].ToString(),
                                FechaRegistro = reader[7].ToString(),
                                Rep=reader[8].ToString()
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

        public static string GetPublicacion(int idperfil)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Publicacion> Publicacion = new List<Publicacion>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "select IDPublicacion,IDPerfil,Titulo,Cuerpo,Fpub,Rating from appdblibro.dbo.publicaciones where IDPerfil=" + idperfil + "";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Publicacion.Add(new Publicacion()
                            {
                                IDPublicacion = reader[0].ToString(),
                                IDPerfil = reader[1].ToString(),
                                Titulo = reader[2].ToString(),
                                Cuerpo = reader[3].ToString(),
                                FechaPublicacion = reader[4].ToString(),
                                Rating = reader[5].ToString()
                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Publicacion);
            return jsonString;
        }

        [WebMethod]

        public static void seguir(int idFollowing)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {



                //String sql = "SELECT Usuario,Contrasena FROM appdblibros.perfil where Usuario='" + Username + "' and Contrasena='" + password + "'";
                String sql = "insert into appdblibro.dbo.seguidores (seguido,seguidor,fecha) values ("+idFollowing+","+ HttpContext.Current.Session["IdUser"] + ",GETDATE())";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                       


                        }
                    }
                }
            }
        }


        [WebMethod]
        public static void noseguir(int idFollowing)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {



               
                String sql = "delete from appdblibro.dbo.seguidores where seguido=" + idFollowing + " and seguidor= "  + HttpContext.Current.Session["IdUser"]+"";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {



                        }
                    }
                }
            }
        }


    }

   
}