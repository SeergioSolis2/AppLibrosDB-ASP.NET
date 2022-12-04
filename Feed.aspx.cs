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
    public partial class Feed : System.Web.UI.Page
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

        public static string GetSeguidos()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Perfil> Perfil = new List<Perfil>();

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "SELECT seguido,seguidor FROM appdblibro.dbo.seguidores where seguidor="+HttpContext.Current.Session["IdUser"]+"";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Perfil.Add(new Perfil()
                            {
                               Followings=reader[0].ToString(),
                               Followers=reader[1].ToString()
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

        public static string GetPublicacionFeed(string seguido)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Publicacion> Publicacion = new List<Publicacion>();
         ;
            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "SELECT IDPublicacion,A.IDPerfil,Titulo,Cuerpo,Fpub,Rating,CONCAT(B.Nombres,' ',B.Apellido_P,' ',B.Apellido_M) from appdblibro.dbo.publicaciones A join appdblibro.dbo.perfil B on B.IDPerfil=A.IDPerfil where  A.IDPerfil in (" + seguido +") order by Fpub desc;";
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
                                Rating = reader[5].ToString(),
                                NombrePerfil=reader[6].ToString(),
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
        public static void GenerarComentario(int IdPerfil, int IdPublicacion, string Comentario)
        {


            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "INSERT INTO appdblibro.dbo.comentarios (IDPublicacion,IDPerfil,Comentario,Fcom,Rating) values (" + IdPublicacion + "," + IdPerfil + ",'" + Comentario + "',GETDATE(),0)";
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

        public static string GetComentarios(int id)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Comentarios> Comentarios = new List<Comentarios>();
            ;
            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "SELECT IDPublicacion,A.IDPerfil,Comentario,Fcom,CONCAT(B.Nombres,' ',B.Apellido_P,' ',B.Apellido_M),IDComentario FROM appdblibro.dbo.comentarios A join appdblibro.dbo.perfil B on A.IDPerfil=B.IDPerfil where IDPublicacion=" + id+"";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                           Comentarios.Add(new Comentarios()
                            {
                             IDPublicacion=reader[0].ToString(),
                             IDPerfil=reader[1].ToString(),
                             Comentario=reader[2].ToString(),
                             Fecha_Comentario=reader[3].ToString(),
                             Nombre=reader[4].ToString(),
                             IDComentario=reader[5].ToString()
                            }
                            );




                        }
                    }
                }
            }

            string jsonString = js.Serialize(Comentarios);
            return jsonString;
        }


        [WebMethod]

        public static void EliminarComentario(int idcomentario)
        {

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "DELETE FROM appdblibro.dbo.comentarios WHERE IDComentario="+idcomentario+"";
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
        public static void CambiosComentario(int IDCOMENTARIO,string mensajecomentario)
        {

            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "Update appdblibro.dbo.comentarios SET Comentario='"+mensajecomentario+"' where IDComentario="+IDCOMENTARIO+" ";
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
        public static void CalificarPublicacion(int idpublicacion, int idperfil,int Evaluacion)
        {
            int flag = 0;
            int promediopublicacion = 0;
            using (SqlConnection connection = new SqlConnection(conexion))
            {



                String sql = "select * from appdblibro.dbo.rating where IDPublicacion="+idpublicacion+" and IDPerfil="+idperfil+"";
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
                     sql = "insert into appdblibro.dbo.rating(IDPublicacion,IDPerfil,Evaluacion) values ("+idpublicacion+","+idperfil+","+Evaluacion+")";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                     
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                  
                        }
                    }
                }

                if (flag == 1)
                {
                     sql = "update appdblibro.dbo.rating set Evaluacion="+Evaluacion+" where IDPerfil="+idperfil+" and IDPublicacion="+idpublicacion+"";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                     
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            

                        }
                    }
                }

                sql = "SELECT AVG(Evaluacion) from appdblibro.dbo.rating where IDPublicacion="+idpublicacion+"";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            promediopublicacion = int.Parse(reader[0].ToString());
                        }

                    }
                }

                sql = "update appdblibro.dbo.publicaciones set Rating="+promediopublicacion+" where IDPublicacion="+idpublicacion+"";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                    }
                }


            }
        }



    }



}