const DivPublicaciones = document.querySelector("#PublicacionesPerfil");
const DivComentarios = document.querySelector("#Comentariospublicacion");
const comentario = document.querySelector("#comentario")
const ModalComentario = document.querySelector("#ComentarBtn");
const ModalEditComentario = document.querySelector("#EditarComentarBtn")

let seguidos = []
var IDPUBLICACION = 0;
var IDPERFIL = 0;
var IDCOMENTARIO = 0;


document.addEventListener("DOMContentLoaded", async function (event) {
    seguidos = [];
    await GetSeguidos();

})


async function GetSeguidos() {
    seguidos = [];
    await fetch('Feed.aspx/GetSeguidos', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },

    })
        .then(response => response.json())
        .then(data => {
            const Seguidos = JSON.parse(data.d)
            console.log(Seguidos)
            Seguidos.forEach(seguido => {
                seguidos.push(seguido.Followings);
                IDPERFIL = seguido.Followers;

            }
            )

        })

        .catch(error => console.error('Error:', error))
    await GetPublicacion();

}

async function GetPublicacion() {
    var seguido=0
    for (i = 0; i < seguidos.length; i++) {
        if (i + 1 < seguidos.length) {
            seguido +=","+ seguidos[i] + ","
        } else {
            seguido +=  seguidos[i]
        }
           
    }
    const Datos = {seguido}
    DivPublicaciones.innerHTML = "";
    console.log(seguido)
    await fetch('Feed.aspx/GetPublicacionFeed', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body:JSON.stringify(Datos)

    })
        .then(response => response.json())
        .then(data => {
            const Publicaciones = JSON.parse(data.d)
            console.log(Publicaciones)
            if (Publicaciones.length <= 0) {
                var div = document.createElement('div');
                div.classList = 'card'
                div.style.border = "5px solid gray";
                div.style.marginTop = "15px";
                div.style.marginBottom = "15px";
                div.innerHTML = `<div class="card-header">
             
                    <div class="card-body" style="text-align:center">
                        
                     
                  
                                <span>NO HAY PUBLICACIONES RECIENTES (SIGUE A MAS PERSONAS)</span>
                        
                        </div>                
                      </div>
                  </div>`

                DivPublicaciones.appendChild(div);
            }
            Publicaciones.forEach(publicacion => {
                var div = document.createElement('div');
                div.classList = 'card'
                div.style.border = "5px solid gray";
                div.style.marginTop = "15px";
                div.style.marginBottom = "15px";

                div.innerHTML = `<div class="card-header">
                    <label style="margin-top:5px;color:red">${publicacion.NombrePerfil.toUpperCase()}</label><br>
                  <label style="margin-top:5px;">ASUNTO: ${publicacion.Titulo.toUpperCase()}</label>
                    <div class="card-body">
                        
                        <p class="card-text">­­- ${publicacion.Cuerpo}</p>
                        <br><br>
                        <span style="font-size:20px;vertical-align: middle;">${publicacion.Rating}</span>&nbsp<img src="Image/Estrella.png" style="width:25px;heigth:25px;" ></img>
                        <div style="text-align:right">
                                <span>${publicacion.FechaPublicacion}</span>
                        </div>
                        <div style="text-align:left">
                                <input type="button" data-bs-toggle="modal" data-bs-target="#calificarModal"  class="btn-warning" onclick="Calificar(${publicacion.IDPublicacion})" value="Calificar">
                                <input type="button" class="btn-success" data-bs-toggle="modal" data-bs-target="#comentarModal" onclick="Getcomentarios(${publicacion.IDPublicacion})" value="Comentar">
                        </div>

                      </div>
                  </div>`

                DivPublicaciones.appendChild(div);
            }
            )

            return Publicaciones

        })

        .catch(error => console.error('Error:', error))




}



async function Getcomentarios(id) {
    comentario.value = "";
    DivComentarios.innerHTML = "";
    IDPUBLICACION = id;
    const Datos = {id}
    await fetch('Feed.aspx/GetComentarios', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Datos)

    })

        .then(response => response.json())
        .then(data => {
            const Publicaciones = JSON.parse(data.d)
            console.log(Publicaciones)
            if (Publicaciones.length <= 0) {
                var div = document.createElement('div');
                div.classList = 'card'
                div.style.border = "5px solid gray";
                div.style.marginTop = "15px";
                div.style.marginBottom = "15px";
                div.innerHTML = `<div class="card-header">
             
                    <div class="card-body" style="text-align:center">
                        
                     
                  
                                <span>NO HAY COMENTARIOS </span>
                        
                        </div>                
                      </div>
                  </div>`

                DivComentarios.appendChild(div);
            }
            Publicaciones.forEach(publicacion => {
                var div = document.createElement('div');
                div.classList = 'card'
                div.style.border = "5px solid gray";
                div.style.marginTop = "15px";
                div.style.marginBottom = "15px";
                
              
                 
                div.innerHTML = `<div class="card-header">
                    <label style="margin-top:5px;color:red">${publicacion.Nombre.toUpperCase()}</label>
                    <div class="card-body">
                        
                        <p class="card-text">­­- ${publicacion.Comentario}</p>
                    
                       
                        <div style="text-align:right">
                                <span>${publicacion.Fecha_Comentario }</span>
                        </div>
                        

                      </div>
                  </div>`
                if (publicacion.IDPerfil == IDPERFIL) {
         
                    div.innerHTML += `
                     <input type="button" class="btn-warning" onclick="EditarComentario(${publicacion.IDComentario} )" value="Editar"/>
                    <input type="button" class="btn-danger" onclick="EliminarComentario(${publicacion.IDComentario})" value = "Eliminar"/> `
                }

                DivComentarios.appendChild(div)
               
            }
            )

         

        })

        .catch(error => console.error('Error:', error))
}


async function GenerarComentario() {
    var IdPerfil = IDPERFIL;
    var IdPublicacion = IDPUBLICACION;
    var Comentario = comentario.value;
    if (comentario.value.trim().length < 1) {
        Swal.fire('El comentario es muy corto o nulo', '', 'error')
        return
    }
    const Datos = { IdPerfil, IdPublicacion, Comentario }
    console.log(Datos);
    await fetch('Feed.aspx/GenerarComentario', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Datos)

    })
    comentario.value = "";
    await Getcomentarios(IdPublicacion);
}




async function EliminarComentario(idcomentario) {
    const datos = { idcomentario }

    Swal.fire({
        title: '¿Deseas eliminar este comentario?',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Yes',
        denyButtonText: 'No',

    }).then( (result) => {
        if (result.isConfirmed) {
          
            Swal.fire('Se elimino correctamente el comentario', '', 'success')
            fetch('Feed.aspx/EliminarComentario', {

                method: 'POST', // or 'PUT'
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(datos)
            })

            Getcomentarios(IDPUBLICACION);
        }
    })

  
}


async function EditarComentario(idcomentario) {
    ModalEditComentario.classList.remove('ocultobtn');
    ModalComentario.classList.add('ocultobtn')
    IDCOMENTARIO=idcomentario
    var id = IDPUBLICACION
    const Datos = {id}
    await fetch('Feed.aspx/GetComentarios', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Datos)

    })

        .then(response => response.json())
        .then(data => {
            const Publicaciones = JSON.parse(data.d)
            Publicaciones.forEach(publicacion => {
                if (publicacion.IDComentario == idcomentario) {
                    comentario.value=publicacion.Comentario
                }

            }
            )



        })

        .catch(error => console.error('Error:', error))

}

async function CambiosComentario() {
    var mensajecomentario = comentario.value;
    const Datos = {IDCOMENTARIO,mensajecomentario}
    await fetch('Feed.aspx/CambiosComentario', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Datos)

    })
    ModalEditComentario.classList.add('ocultobtn');
    ModalComentario.classList.remove('ocultobtn');
    await Getcomentarios(IDPUBLICACION);
}


function Calificar(idpublicacion){
    IDPUBLICACION=idpublicacion
}

async function CalificarPublicacion() {
    var idpublicacion=IDPUBLICACION
    var idperfil = IDPERFIL;
    var Evaluacion = $('input:radio[name=estrellas]:checked').val();
    const Datos = {idpublicacion,idperfil,Evaluacion}
    console.log(Datos);

    await fetch('Feed.aspx/CalificarPublicacion', {

       method: 'POST', // or 'PUT'
       headers: {
           'Content-Type': 'application/json',
       },
       body: JSON.stringify(Datos)

    })
      
       
       
    await GetSeguidos();
   
}