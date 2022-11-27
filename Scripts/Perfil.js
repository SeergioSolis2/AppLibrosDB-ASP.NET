const NombrePerfil = document.querySelector("#NombrePerfil");
const username = document.querySelector("#Username");

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
                username.innerHTML=`@${users.Usuario}`
            }
            )

            return Usuarios

        })

        .catch(error => console.error('Error:', error))
}