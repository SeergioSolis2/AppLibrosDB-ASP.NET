const NombrePerfil = document.querySelector("#NombrePerfil");
const username = document.querySelector("#Username");
const CorreoPerfil = document.querySelector("#CorreoPerfil");
const JoinPerfil = document.querySelector("#join");
const FollowerPerfil = document.querySelector("#Followers");
const FollowingsPerfil = document.querySelector("#Followings");
const EditNombre = document.querySelector("#EditNombre");
const EditApellidoP = document.querySelector("#EditApellido_Paterno");
const EditApellidoM = document.querySelector("#EditApellido_Materno");
const EditUser = document.querySelector("#Edituser");
const EditEmail = document.querySelector("#EditEmail");
const TextoPublicacion = document.querySelector("#TextoPublicacion");
const TituloPublicacion = document.querySelector("#TituloPublicacion");
const DivPublicaciones = document.querySelector("#PublicacionesPerfil");
const EditTextoPublicacion = document.querySelector("#EditTextoPublicacion");
const EditTituloPublicacion = document.querySelector("#EditTituloPublicacion");
const SelectBuscar = document.querySelector('#NewLibroSelect')
const DivLibros = document.querySelector('#Tuslibros');
var IDPublicacion = 0;
var IDPerfil = 0;
document.addEventListener("DOMContentLoaded", async function (event) {
    await Gettuslibros();
    await llenarBuscador();
    await Reputacionperfil();
    await DatosPerfil();
    await GetPublicacion();
    $('#NewLibroSelect').select2();

   
})

$("#btnlibro").on("click", async function () {

    if ($('#NewLibroSelect').val() != 0) {
        await InsertarLibro($('#NewLibroSelect').val())
        await Gettuslibros();

    } else {
        Swal.fire('Selecciona un libro', '', 'error')
    }

});


async function Gettuslibros() {
    DivLibros.innerHTML = "";
    await fetch('Profile.aspx/Gettuslibros', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
       

    })

        .then(response => response.json())
        .then(data => {
            const Libros = JSON.parse(data.d)

            Libros.forEach(libro => {
                var tr = document.createElement("tr");
                
                     tr.innerHTML = `<td>${libro.ISBN}</td>
                     <td>${libro.Autor}</td>
                     <td>${libro.Titulo}</td>
                     <td>${libro.Edicion}</td>
                     <td>${libro.Editorial}</td>
                     <td>${libro.Lugar}</td>
                     <td>${libro.Anio}</td>
                     <td>${libro.Paginas}</td>
                     <td>${libro.Rating} &nbsp<img src="Image/Estrella.png" style="width:25px;heigth:25px;" ></img></td>
                     <td><input type="button" value="Eliminar" class="btn-danger" onclick="EliminarLibro(${libro.ISBN})"</td>`
               
                DivLibros.appendChild(tr);
            }
            )



        })

        .catch(error => console.error('Error:', error))
}


async function EliminarLibro(id) {
    const Datos = { id }
    Swal.fire({
        title: '¿Deseas eliminar este Libro?',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Yes',
        denyButtonText: 'No',

    }).then(async (result) => {
        if (result.isConfirmed) {
            Swal.fire('Se elimino el libro Correctamente', '', 'success')
            await fetch('Profile.aspx/EliminarLibro', {

                method: 'POST', // or 'PUT'
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(Datos)

            })

            await Gettuslibros();
        }
    })
    
   
 
}


async function InsertarLibro(id) {
    const Datos = {id}
    await fetch('Profile.aspx/InsertarLibro', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Datos)

    })
}

async function llenarBuscador() {
    await fetch('Profile.aspx/GetLibros', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },

    })
        .then(response => response.json())
        .then(data => {
            const Libros = JSON.parse(data.d)
           
            Libros.forEach(libro => {
                var Option = document.createElement('option')
                Option.value = libro.ISBN
                Option.textContent = libro.Titulo
                SelectBuscar.appendChild(Option)

            }
            )



        })

        .catch(error => console.error('Error:', error))


}



async function Reputacionperfil() {
    await fetch('Profile.aspx/Reputacionperfil', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
   

    })
}



async function DeletePublicacion(id) {
    const datos = { id }

    Swal.fire({
        title: '¿Deseas eliminar esta publicacion?',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Yes',
        denyButtonText: 'No',
    
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire('Eliminacion de la publicacion realizada correctamente', '', 'success')
             fetch('Profile.aspx/DeletePublicacion', {

                method: 'POST', // or 'PUT'
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(datos)
             })

            GetPublicacion();
        } 
    })

 


}


async function EjecutarEditar() {

     var titulo =EditTituloPublicacion.value;
    var Cuerpo = EditTextoPublicacion.value;
    var ID = IDPublicacion 
    const Datos = { titulo, Cuerpo, ID };
    console.log(Datos);
 
    await fetch('Profile.aspx/EditarPublicacion', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body:  JSON.stringify(Datos)

    })

    await GetPublicacion();
  

}


async function ModalEditar(id) {
    
    await fetch('Profile.aspx/GetPublicacion', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },

    })
        .then(response => response.json())
        .then(data => {
            const Publicaciones = JSON.parse(data.d)
            console.log(Publicaciones)
            Publicaciones.forEach(publicacion => {

                if (publicacion.IDPublicacion == id) {
                    EditTituloPublicacion.value = publicacion.Titulo;
                    EditTextoPublicacion.value = publicacion.Cuerpo;
                    IDPublicacion=publicacion.IDPublicacion
                }
          
            }
            )

        })

        .catch(error => console.error('Error:', error))

}


async function GetPublicacion() {
    DivPublicaciones.innerHTML = "";
    await fetch('Profile.aspx/GetPublicacion', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },

    })
        .then(response => response.json())
        .then(data => {
            const Publicaciones = JSON.parse(data.d)
            console.log(Publicaciones)
            Publicaciones.forEach(publicacion => {
                var div = document.createElement('div');
                div.classList = 'card'
                div.style.border = "5px solid gray";
                div.style.marginTop = "15px";
                div.style.marginBottom = "15px";

                div.innerHTML = `<div class="card-header">
                  <label style="margin-top:5px;">${publicacion.Titulo.toUpperCase()}</label>
                    <div class="card-body">
                        
                        <p class="card-text">­­- ${publicacion.Cuerpo}</p>
                        <br><br>
                        <span style="font-size:20px;vertical-align: middle;">${publicacion.Rating}</span>&nbsp<img src="Image/Estrella.png" style="width:25px;heigth:25px;" ></img>
                        <div style="text-align:right">
                                <span>${publicacion.FechaPublicacion}</span>
                        
                        </div>
                        <div style="text-align:left">
                               <input type="button" class="btn-danger" onclick=DeletePublicacion(${publicacion.IDPublicacion}) value="Eliminar Publicacion">
                                <input  data-bs-toggle="modal" data-bs-target="#EditPublicacion" type="button" class="btn-warning"  onclick=ModalEditar(${publicacion.IDPublicacion})  value="Editar Publicacion" />
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

async function NewPublicacion() {
    var titulo = TituloPublicacion.value;
    var contenido = TextoPublicacion.value;
    const Datos = { titulo, contenido }
    if (titulo != "" && contenido != "") {
        await fetch('Profile.aspx/NewPublicacion', {

            method: 'POST', // or 'PUT'
            headers: {

                'Content-Type': 'application/json',
            },
            body: JSON.stringify(Datos)

        })
    } 
    await GetPublicacion();
    

}


async function EditarPerfil() {
 
 

    var Nombres = EditNombre.value;
    var Apellido_P = EditApellidoP.value;
    var Apellido_M = EditApellidoM.value;
    var Usuario = EditUser.value;
    var Email = EditEmail.value;

    const Datos = { Nombres, Apellido_P, Apellido_M, Usuario, Email }

    console.log(Datos);

    await fetch('Profile.aspx/EditarPerfil', {

        method: 'POST', // or 'PUT'
        headers: {
           
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Datos)

    })

    await DatosPerfil();


}


async function DatosPerfil() {
    await fetch('Profile.aspx/GetPerfil', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
 
    })
        .then(response => response.json())
        .then(data => {
            const Usuarios = JSON.parse(data.d)
            console.log(Usuarios)
            Usuarios.forEach(users => {
                console.log(users);
                NombrePerfil.innerHTML = `${users.Nombres + " " + users.ApellidoP + " " + users.ApellidoM}`;
                username.innerHTML = `@${users.Usuario}`;
                CorreoPerfil.innerHTML = `${users.Email}`;
                IDPerfil = users.IDPerfil;
                JoinPerfil.innerHTML = `<span style="font-size:20px;vertical-align: middle;">${users.Rep}</span>&nbsp<img src="Image/Estrella.png" style="width:25px;heigth:25px;" ></img><br><label style="">Joined </label><br>${users.FechaRegistro}`;
                EditNombre.value=users.Nombres
                EditApellidoP.value =users.ApellidoP
                EditApellidoM.value = users.ApellidoM
                EditUser.value = users.Usuario
                EditEmail.value = users.Email
            }
            )

            return Usuarios

        })

        .catch(error => console.error('Error:', error))
        await ConteoFollowers(IDPerfil);

}


async function ConteoFollowers(idPerfil) {
    const Datos={ idPerfil }
    await fetch('Profile.aspx/ConteoFollowers', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body:JSON.stringify(Datos)

    })
        .then(response => response.json())
        .then(data => {
            const Followers = JSON.parse(data.d)
         
            Followers.forEach(Follow => {
                console.log(Follow)
                FollowerPerfil.innerHTML = `${Follow.Followers} Seguidores`
                FollowingsPerfil.innerHTML = `${Follow.Followings} Seguidos`
            }
            )

            return Followers

        })

        .catch(error => console.error('Error:', error))




}