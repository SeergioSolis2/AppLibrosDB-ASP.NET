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
var IDPerfil = 0;
document.addEventListener("DOMContentLoaded", async function (event) {

   await DatosPerfil();

})


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
                EditNombre.outerHTML = `<input id="EditNombre" type="text" class="col-12" placeholder="Nombre Completo" value="${users.Nombres}" />`
                EditApellidoP.outerHTML =`<input id="EditApellido_Paterno" type="text" class="col-12" placeholder="Apellido Paterno"  value="${users.ApellidoP}"/>`
                EditApellidoM.outerHTML = ` <input id="EditApellido_Materno" type="text" class="col-12" placeholder="Apellido Paterno" value="${users.ApellidoM}" />`
                EditUser.outerHTML = `<input id="Edituser" type="text" class="col-12" placeholder="Usuario" value="${users.Usuario}" />`
                EditEmail.outerHTML = `<input id="EditEmail" type="text" class="col-12" placeholder="Email" value="${users.Email}"/>`
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