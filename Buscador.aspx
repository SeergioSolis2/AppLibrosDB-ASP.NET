<%@ Page Title="Buscador" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Buscador.aspx.cs" Inherits="AppLibrosDB.Buscador"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="row">
        <div class="col-12">
            <select class="col-12" id="Buscador" >
                <option disabled="disabled" selected>Buscar Usuario</option>
            </select>
        </div>
    </div>

    <br />

    <div class="row oculto" id="ViewPerfil">
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
                <div class=" d-flex mt-2" id="btnPerfil"> 
                <%--   < input class="btn btn-outline-primary col-12"  type="button" value="Seguir"></input>--%>

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
         <div class="col-12" id="PublicacionesPerfil">
        </div>
        </div>
       </div>


    <br />
    <br />
     <div class="row oculto" style="margin-left:10px;" id="LibrosBuscador" >
        <div class="col-12" style="border:5px solid gray;border-radius:10px;height:500px;overflow:auto;background-color:whitesmoke;text-align:center" >
            <br />
            <label>BIBLIOTECA</label>
         
            <br />
            <div class="col-12" >
                <table class="table  col-12">
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
                          
                        </tr>
                    </thead>
                    <tbody id="Tuslibros">

                    </tbody>
                </table>
            </div>
            
        </div>
    </div>

</asp:Content>



