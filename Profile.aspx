<%@ Page Title="Perfil" Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="AppLibrosDB.Profile"  MasterPageFile="~/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="row">
        <div class="col-3  justify-content-left"  > 
        <div class="card p-4" style="border:5px solid gray;background-color:white;border-radius:10px"> 
            <div class=" image d-flex flex-column justify-content-center align-items-center" style="background-color:floralwhite;border:5px solid black;border-radius:10px"> 
                <span style="background-color:floralwhite;" > 
                <img src="Image/FotoPerfil.png" height="100" width="100" /></span> 
                <span id="NombrePerfil" class="name mt-3"></span> 
                <span id="Username" class="idd"></span> 
                <div class="d-flex flex-row justify-content-center align-items-center gap-2"> 
                    <span id="CorreoPerfil"class="idd1"></span> 
             

                </div> 
                <div class=" justify-content-center align-items-center "> 
                    <span id="Followers" class="number"> </span> 
            
                     <span id="Followings" class="number"> </span> 

                </div> 
                <div class=" d-flex mt-2"> 
                    <input  class="btn btn-outline-success col-12" data-bs-toggle="modal" data-bs-target="#EditModal" type="button" value="Editar Perfil"></input>

                </div> 
                <div class="text mt-3"> 
                    <span>
                        <br>
                        <br> 

                    </span> 

                </div> 
                <div class="gap-3 mt-3 icons d-flex flex-row justify-content-center align-items-center"> 
              

                </div> 
                <div class="col-12 date" style="text-align:center"> 
                    <span id="join" class="join" style="text-align:center;"></span> 

                </div> 

            </div> 

        </div>
        </div>

        <div class="col-9" style="border:5px solid gray;border-radius:25px;background-color:whitesmoke" >
             <input  data-bs-toggle="modal" data-bs-target="#NewPublicacion" type="button" class="btn-success" value="Nueva Publicacion" style="margin-top:5px;border-radius:10px;"/>
             <div class="col-12" id="PublicacionesPerfil">
        </div>
    


    </div>
    
    <!-- Modal Editar Publicacion -->
<div class="modal fade" id="EditPublicacion" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <img src="Image/R_Logo.png" style="width:25px;height:25px" />
          <p>&ensp;</p>
        <h5 class="modal-title">Editar Publicacion</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
   
      <div class="modal-body">
          <div class="col-12" >
                <label>Titulo:</label>
                <br />
                <input id="EditTituloPublicacion" type="text" class="col-12" placeholder="Titulo" />
          </div>
          <br />
        
          <div class="col-12" >
                <label>Mensaje:</label>
                <br />
                <textarea class="col-12" id="EditTextoPublicacion" rows="8" cols="50" placeholder="Escribe algo..."></textarea>
              
          </div>
           <br />
        

         
      
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-success" onclick="EjecutarEditar()" data-bs-dismiss="modal">Editar</button>
      </div>
    </div>
  </div>
</div>




    <!-- Modal Publicacion -->
<div class="modal fade" id="NewPublicacion" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <img src="Image/R_Logo.png" style="width:25px;height:25px" />
          <p>&ensp;</p>
        <h5 class="modal-title" id="Publicacion" >Nueva Publicacion</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
   
      <div class="modal-body">
          <div class="col-12" >
                <label>Titulo:</label>
                <br />
                <input id="TituloPublicacion" type="text" class="col-12" placeholder="Titulo" />
          </div>
          <br />
        
          <div class="col-12" >
                <label>Mensaje:</label>
                <br />
                <textarea class="col-12" id="TextoPublicacion" rows="8" cols="50" placeholder="Escribe algo..."></textarea>
              
          </div>
           <br />
        

         
      
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-success" onclick="NewPublicacion()" data-bs-dismiss="modal">Publicar</button>
      </div>
    </div>
  </div>
</div>

    <!-- Modal -->
<div class="modal fade" id="EditModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <img src="Image/R_Logo.png" style="width:25px;height:25px" />
          <p>&ensp;</p>
        <h5 class="modal-title" id="exampleModalLabel" >Editar Perfil</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
   
      <div class="modal-body">
          <div class="col-12" >
                <label>Nombre:</label>
                <br />
                <input id="EditNombre" type="text" class="col-12" placeholder="Nombre Completo" />
          </div>
          <br />
        
          <div class="col-12" >
                <label>Apellido Paterno:</label>
                <br />
                <input id="EditApellido_Paterno" type="text" class="col-12" placeholder="Apellido Paterno" />
          </div>
           <br />
          <div class="col-12" >
                <label>Apellido Materno:</label>
                <br />
                <input id="EditApellido_Materno" type="text" class="col-12" placeholder="Apellido Paterno" />
          </div>
          <br />
          <div class="col-12" >
                <label>Usuario:</label>
                <br />
                <input id="Edituser" type="text" class="col-12" placeholder="Usuario" />
          </div>

            <br />
          <div class="col-12" >
                <label>Email:</label>
                <br />
                <input id="EditEmail" type="text" class="col-12" placeholder="Email" />
          </div>

         
      
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary" onclick="EditarPerfil()" data-bs-dismiss="modal">Editar Perfil</button>
      </div>
    </div>
  </div>
</div>

</asp:Content>


