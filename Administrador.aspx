<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="AppLibrosDB.Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administrador</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>

</head>
<body>
    <div class="row" >
     
         <div class="col-8" style="border:5px solid black;margin-top:15px;margin-left:25px">
                <input type="button" class="btn-outline-success" data-bs-toggle="modal" data-bs-target="#NewLibroModal" value="Nuevo Libro" style="margin-top:10px" />
                <br/> <br/>
                <table class="table ">
                    <thead style="background-color:gray;color:white">
                        <tr>
                             <td>ISBN</td>
                             <td>Autor</td>
                             <td>Titulo</td>
                             <td>Edicion</td>
                             <td>Editorial</td>
                             <td>Lugar</td>
                             <td>Anio</td>
                             <td>Paginas</td>
                             <td>Rating</td>
                             <td>Opciones</td>
                        </tr>
                    </thead>
                    <tbody id="Tuslibros">

                    </tbody>
                </table>
            </div>

    </div>


        <br />
    <div class="row">
        <div class="col-6" style="border:5px solid black;margin-top:15px;margin-left:25px">
            <span>Usuarios</span>
            <table  class="table">
                <thead style="background-color:gray">
                    <tr>
                        <td>IDPerfil</td>
                        <td>Username</td>
                        <td>Nombre</td>
                       
                    </tr>
                    
                </thead>
                <tbody id="tablausuario">

                </tbody>
            </table>

        </div>
      

    </div>

    <br />

    <div class="col-12" style="text-align:center">
           <span >REPORTES</span>
    </div>

    <br />
    <br />
    <div class="row">
        <div class="col-6" style="border:5px solid black;margin-top:15px;margin-left:25px">
            <span>Libros mejor calificados</span>
            <table  class="table">
                <thead style="background-color:gray">
                    <tr>
                        <td>Autor</td>
                        <td>Titulo</td>
                        <td>Rating</td>
                    </tr>
                    
                </thead>
                <tbody id="reporte1">

                </tbody>
            </table>

        </div>
        <div class="col-6" style="border:5px solid black;margin-top:15px;margin-left:25px">
                <span>Libros peor calificados</span>
                <table class="table">
                <thead style="background-color:gray">
                      <tr>
                        <td>Autor</td>
                        <td>Titulo</td>
                        <td>Rating</td>
                    </tr>
                </thead>
                <tbody id="reporte2">

                </tbody>
            </table>
        </div>

    </div>



     <br />
    <div class="row">
        <div class="col-6" style="border:5px solid black;margin-top:15px;margin-left:25px">
            <span>.Libros mas leidos</span>
            <table  class="table">
                <thead style="background-color:gray">
                    <tr>
                        <td>#</td>
                        <td>ISBN</td>
                       
                    </tr>
                    
                </thead>
                <tbody id="reporte3">

                </tbody>
            </table>

        </div>
        <div class="col-6" style="border:5px solid black;margin-top:15px;margin-left:25px">
                <span>Libros menos leidos</span>
                <table class="table">
                <thead style="background-color:gray">
                      <tr>
                      <td>#</td>
                      <td>ISBN</td>
                    </tr>
                </thead>
                <tbody id="reporte4">

                </tbody>
            </table>
        </div>

    </div>



     <br />
    <div class="row">
        <div class="col-6" style="border:5px solid black;margin-top:15px;margin-left:25px">
            <span>Perfiles con Mejor Reputacion</span>
            <table  class="table">
                <thead style="background-color:gray">
                    <tr>
                        <td>Usuario</td>
                        <td>Reputacion</td>
                       
                    </tr>
                    
                </thead>
                <tbody id="reporte5">

                </tbody>
            </table>

        </div>
        <div class="col-6" style="border:5px solid black;margin-top:15px;margin-left:25px">
                <span>Publicacion con Mejor Reputacion</span>
                <table class="table">
                <thead style="background-color:gray">
                      <tr>
                      <td>IDPublicacion</td>
                      <td>Cuerpo</td>
                      <td>Rating</td>
                    </tr>
                </thead>
                <tbody id="reporte6">

                </tbody>
            </table>
        </div>

    </div>




      <br />
    <div class="row">
        <div class="col-6" style="border:5px solid black;margin-top:15px;margin-left:25px">
            <span>Perfiles con mas libros leidos</span>
            <table  class="table">
                <thead style="background-color:gray">
                    <tr>
                        <td>#Libros</td>
                        <td>IDPerfil</td>
                       
                    </tr>
                    
                </thead>
                <tbody id="reporte7">

                </tbody>
            </table>

        </div>
        <div class="col-6" style="border:5px solid black;margin-top:15px;margin-left:25px">
                <span>Perfiles con mas seguidores</span>
                <table class="table">
                <thead style="background-color:gray">
                      <tr>
                      <td>#Followers</td>
                      <td>IDPerfil</td>
                    
                    </tr>
                </thead>
                <tbody id="reporte8">

                </tbody>
            </table>
        </div>

    </div>



          <br />
    <div class="row">
        <div class="col-6" style="border:5px solid black;margin-top:15px;margin-left:25px">
            <span>Perfiles con menos seguidores</span>
            <table  class="table">
                <thead style="background-color:gray">
                    <tr>
                        <td>#Followers</td>
                        <td>IDPerfil</td>
                       
                    </tr>
                    
                </thead>
                <tbody id="reporte9">

                </tbody>
            </table>

        </div>
        <div class="col-6" style="border:5px solid black;margin-top:15px;margin-left:25px">
                <span>Perfiles mas activos</span>
                <table class="table">
                <thead style="background-color:gray">
                      <tr>
                      <td>#Publicaciones</td>
                      <td>IDPerfil</td>
                    
                    </tr>
                </thead>
                <tbody id="reporte10">

                </tbody>
            </table>
        </div>

    </div>
  



    <div class="modal fade" id="NewLibroModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <img src="Image/R_Logo.png" style="width:25px;height:25px" />
        <h5 class="modal-title" id="exampleModalLabel" >Nuevo Libro</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
   
      <div class="modal-body">
          <div class="col-12" >
                <label>ISBN:</label>
                <br />
                <input id="ModalISBN" type="text" class="col-12"  />
          </div>
            <div class="col-12" >
                <label>Autor:</label>
                <br />
                <input id="ModalAutor" type="text" class="col-12"  />
          </div>
           <div class="col-12" >
                <label>Titulo:</label>
                <br />
                <input id="ModalTitulo" type="text" class="col-12"  />
          </div>
            <div class="col-12" >
                <label>Edicion:</label>
                <br />
                <input id="ModalEdicion" type="text" class="col-12"  />
          </div>
             <div class="col-12" >
                <label>Editorial:</label>
                <br />
                <input id="ModalEditorial" type="text" class="col-12"  />
          </div>
            <div class="col-12" >
                <label>Lugar:</label>
                <br />
                <input id="ModalLugar" type="text" class="col-12"  />
          </div>
            <div class="col-12" >
                <label>Año:</label>
                <br />
                <input id="ModalAño" type="text" class="col-12"  />
          </div>
            <div class="col-12" >
                <label>Paginas:</label>
                <br />
                <input id="ModalPaginas" type="text" class="col-12"  />
          </div>
            <div class="col-12" >
                <label>Rating:</label>
                <br />
                <input id="ModalRating" type="number" max="5" class="col-12"  />
          </div>
        
          
      
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary" onclick="NewLibro()" data-bs-dismiss="modal">Guardar Libro</button>
      </div>
    </div>
  </div>
</div>


<script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>  
<script src="Scripts/Administrador.js"></script>
<script src="https://code.jquery.com/jquery-3.6.1.js" integrity="sha256-3zlB5s2uwoUzrXK3BT7AX3FyvojsraNFxCc2vC/7pNI=" crossorigin="anonymous"></script>
<script src="Scripts/bootstrap.js"></script>
</body>
</html>
