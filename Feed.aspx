<%@ Page Title="Feed" Language="C#" AutoEventWireup="true" CodeBehind="~/Feed.aspx.cs" Inherits="AppLibrosDB.Feed"  MasterPageFile="~/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">

    <div class="row col-12">
         <div class="col-12" style="border:5px solid gray;border-radius:25px;background-color:whitesmoke" >
     
             <div class="col-12" id="PublicacionesPerfil">
                    

             </div>
        </div>
    </div>





    <!-- Modal -->
<div class="modal fade" id="calificarModal" tabindex="-1" aria-labelledby="calificarModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content " >
      <div class="modal-header">
        <img src="Image/R_Logo.png" style="width:25px;height:25px" />
        <h5 class="modal-title" id="exampleModalLabel" >CALIFICAR</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
   
      <div class="modal-body">
         <form >
          <p class="clasificacion" style="text-align:center;">
               <input id="radio1" type="radio" name="estrellas" value="5"><!--
            --><label for="radio1" style="font-size:45px">★</label><!--
            --><input id="radio2" type="radio" name="estrellas" value="4"><!--
            --><label for="radio2" style="font-size:45px">★</label><!--
            --><input id="radio3" type="radio" name="estrellas" value="3"><!--
            --><label for="radio3" style="font-size:45px">★</label><!--
            --><input id="radio4" type="radio" name="estrellas" value="2"><!--
            --><label for="radio4" style="font-size:45px">★</label><!--
            --><input id="radio5" type="radio" name="estrellas" value="1"><!--
            --><label for="radio5" style="font-size:45px">★</label>
          </p>
        </form>
        
      
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary" onclick="CalificarPublicacion()" data-bs-dismiss="modal">Calificar</button>
      </div>
    </div>
</div>
</div>

<!--MODAL COMENTARIO-->

 <div class="modal fade" id="comentarModal" tabindex="-1" aria-labelledby="calificarModal" aria-hidden="true" >
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <img src="Image/R_Logo.png" style="width:25px;height:25px" />
        <h5 class="modal-title" id="" >COMENTAR</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
   
      <div class="modal-body">
         
      
            <div class="col-12" id="Comentariospublicacion" style="height:300px;width:500px;overflow:auto" >

            </div>
            <br />
           
          <div class="col-12">

               <textarea id="comentario" class="col-12"  rows="4" cols="50">
              
               </textarea>
       
          </div>
       
      
      </div>
      <div class="modal-footer" id="FooterModalComentarios">
        <input class="btn-warning ocultobtn" type="button" id="EditarComentarBtn" onclick="CambiosComentario()" value="Guardar Cambios" />
        <input class="btn-success " type="button" id="ComentarBtn" onclick="GenerarComentario()" value="Comentar" />
   
   
   </div>
</div>
</div>

</asp:Content>