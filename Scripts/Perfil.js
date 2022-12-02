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
const Perfilesmsg = document.querySelector("#Perfilesmsg");

var IDPerfil = 0;
document.addEventListener("DOMContentLoaded", async function (event) {

   await DatosPerfil();

})

async function EditarPerfil() 


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
                JoinPerfil.innerHTML = `<label style="">Joined </label><br>${users.FechaRegistro}`;
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


async function cargarPerfiles(idPerfil) {
    const Datos={ idPerfil }
    await fetch('Profile.aspx/cargarperfiles', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body:JSON.stringify(Datos)

    })
        .then(response => response.json())
        .then(data => {
            const perfiles = JSON.parse(data.d)
            
            perfiles.forEach(Perfil => {
                console.log(Perfil)
                var a = parent.document.createElement("a")
                a.setAttribute("id", Perfil.IDPerfil)
                a.innerHTML = Perfil.Nombres
                Perfilesmsg.appendChild(a)
                    
            }
            )

    return perfiles;

})

        .catch(error => console.error('Error:', error))




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