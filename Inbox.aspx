<%@ Page Title="Inbox" Language="C#" AutoEventWireup="true" CodeBehind="~/Inbox.aspx.cs" Inherits="AppLibrosDB.Inbox"  MasterPageFile="~/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <link rel="stylesheet" href="css/inbox.css" />
    <div class="row">
       

        <div class="col-10" id="messages" style="border:5px solid black;height:500px;overflow:scroll;background-color:whitesmoke">
            <input id="aidi" type="text" hidden>
        </div>
        <div class="col-2"  id="Perfilesmsg" style="border:5px solid black;background-color:whitesmoke">
            
        </div>
        <br/><br/>
        <div style="margin-top:20px">
        <input class="col-6" type="text" id="msg"/>
        <input class="col-2 btn-outline-primary" type="button" onclick="agregarMensajes()" value="Enviar"></input>
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


