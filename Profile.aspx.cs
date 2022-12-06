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

        public static void EliminarLibro(int id)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = " Delete from appdblibro.dbo.leidos where ISBN="+id+" and IDPerfil=" + HttpContext.Current.Session["IdUser"] + "";
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
        public static string Gettuslibros()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Libro> Libro = new List<Libro>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = " select A.ISBN,Autor,Titulo,Edicion,Editorial,Lugar,Anio,Paginas,Rating from appdblibro.dbo.libros A join appdblibro.dbo.leidos B on B.ISBN=A.ISBN where B.IDPerfil="+HttpContext.Current.Session["IdUser"]+"";
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
                                Lugar=reader[5].ToString(),
                                Anio=reader[6].ToString(),
                                Paginas=reader[7].ToString(),
                                Rating=reader[8].ToString(),
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

        public static void InsertarLibro(int id)
        {
            int flag = 0;
            using (SqlConnection connection = new SqlConnection(conexion))
            {

                String sql = "Select * From appdblibro.dbo.leidos where  ISBN=" + id + "and IDPerfil=" + HttpContext.Current.Session["IdUser"] + "";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            flag = 1;

                        }

                    }
                }
                if (flag == 0)
                {
                    sql = "insert into appdblibro.dbo.leidos (ISBN,IDPerfil) values (" + id + "," + HttpContext.Current.Session["IdUser"] + ")";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                       
                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                        }
                    }
                }
                
            }
        }

        [WebMethod]
        public static string GetLibros()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Libro> Libro = new List<Libro>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = " SELECT Titulo,ISBN FROM appdblibro.DBO.libros;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Libro.Add(new Libro()
                            {
                                Titulo=reader[0].ToString(),
                                ISBN=reader[1].ToString(),
                              
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
        public static string GetPerfil()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Perfil> Perfil = new List<Perfil>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "SELECT Nombres,Apellido_P,Apellido_M,Usuario,Email,IDPerfil,Fnac,CONVERT (char(10), Freg, 103),Rep FROM appdblibro.dbo.perfil where (Usuario='" + HttpContext.Current.Session["Usuario"] + "' ) or (Email='" + HttpContext.Current.Session["Usuario"] + "') ;";
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
                                FechaRegistro=reader[7].ToString(),
                                Rep= reader[8].ToString()
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
        public static void Reputacionperfil()
        {
            int promedioreputacion = 0;
            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "Select AVG(rating) from appdblibro.dbo.publicaciones where IDPerfil="+HttpContext.Current.Session["IdUser"] + "";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader=command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader[0].ToString() != "")
                            {
                                promedioreputacion = int.Parse(reader[0].ToString());
                            }
                         

                        }
                    }
                }


                sql = "update appdblibro.dbo.perfil set Rep="+promedioreputacion+" where IDPerfil="+ HttpContext.Current.Session["IdUser"] + "";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {



                    }
                }
            }
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

        public static void NewPublicacion(string titulo, string contenido)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "insert into appdblibro.dbo.publicaciones (IDPerfil,Titulo,Cuerpo,Fpub,Rating) values ("+HttpContext.Current.Session["IdUser"]+",'" + titulo+"','"+contenido+"',GETDATE(),0) ";

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
        public static void DeletePublicacion(int id)
        {
           

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "delete from appdblibro.dbo.publicaciones where IDPublicacion="+id+"";
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

        public static string GetPublicacion()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Publicacion> Publicacion = new List<Publicacion>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "select IDPublicacion,IDPerfil,Titulo,Cuerpo,Fpub,Rating from appdblibro.dbo.publicaciones where IDPerfil="+ HttpContext.Current.Session["IdUser"] + "";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Publicacion.Add(new Publicacion()
                            {
                                IDPublicacion=reader[0].ToString(),
                                IDPerfil=reader[1].ToString(),
                                Titulo=reader[2].ToString(),
                                Cuerpo=reader[3].ToString(),
                                FechaPublicacion=reader[4].ToString(),
                                Rating=reader[5].ToString()
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

        public static void EditarPublicacion(string titulo, string Cuerpo, int ID )
        {

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "update appdblibro.dbo.publicaciones set Cuerpo='"+Cuerpo+"',Titulo='"+titulo+"',Fpub=GETDATE() where IDPublicacion="+ID+"";
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