const SelectBuscar = document.querySelector("#Buscador");
const NombrePerfil = document.querySelector("#NombrePerfil");
const username = document.querySelector("#Username");
const CorreoPerfil = document.querySelector("#CorreoPerfil");
const JoinPerfil = document.querySelector("#join");
const FollowerPerfil = document.querySelector("#Followers");
const FollowingsPerfil = document.querySelector("#Followings");
const DivPublicaciones = document.querySelector("#PublicacionesPerfil");
const BotonPerfil = document.querySelector("#btnPerfil")
var Idperfilvisitado = "";
let seguidos = []
document.addEventListener("DOMContentLoaded", async function (event) {
    
    await llenarBuscador();
    await GetSeguidos();
    $("#Buscador").on("change", async function () {
        $('#ViewPerfil').removeClass('oculto')
        await Reputacionperfil($(this).val())
        await DatosPerfil($(this).val());
        await GetPublicacion($(this).val());
      
    });

    $('#Buscador').select2();
})

async function Reputacionperfil(idperfil) {
    const Datos = {idperfil}
    await fetch('Buscador.aspx/Reputacionperfil', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Datos)


    })
}

async function GetSeguidos(id) {
    seguidos=[]
    await fetch('Feed.aspx/GetSeguidos', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },

    })
        .then(response => response.json())
        .then(async data => {
            const Seguidos = JSON.parse(data.d)
            console.log(Seguidos)
            await Seguidos.forEach(seguido => {
                seguidos.push(seguido.Followings);
            }
            )

        })

        .catch(error => console.error('Error:', error))
   

}

async function GetPublicacion(id) {
    var idperfil = id;
    const Datos = { idperfil }
    DivPublicaciones.innerHTML = "";
    await fetch('Buscador.aspx/GetPublicacion', {

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
                       
                      </div>
                  </div>`

                DivPublicaciones.appendChild(div);
            }
            )

            return Publicaciones

        })

        .catch(error => console.error('Error:', error))




}

async function llenarBuscador() {
    await fetch('Buscador.aspx/GetUser', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
      
    })
        .then(response => response.json())
        .then(data => {
            const Usuarios = JSON.parse(data.d)
            console.log(Usuarios)
            Usuarios.forEach(Usuario => {
                var Option = document.createElement('option')
                Option.value=Usuario.IDPerfil
                Option.textContent = Usuario.Nombres+" " + Usuario.ApellidoP +" "+ Usuario.ApellidoM
                SelectBuscar.appendChild(Option)

            }
            )

         

        })

        .catch(error => console.error('Error:', error))

  
}


async function DatosPerfil(id) {
    var idperfil = id;
    const Datos = {idperfil}
    await fetch('Buscador.aspx/GetPerfil', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Datos)

    })
        .then(response => response.json())
        .then(data => {
            const Usuarios = JSON.parse(data.d)
            console.log(Usuarios)
            Usuarios.forEach(users => {
                var band = 0;
                console.log(users);
                NombrePerfil.innerHTML = `${users.Nombres + " " + users.ApellidoP + " " + users.ApellidoM}`;
                username.innerHTML = `@${users.Usuario}`;
                CorreoPerfil.innerHTML = `${users.Email}`;
                IDPerfil = users.IDPerfil;
                JoinPerfil.innerHTML = `<span style="font-size:20px;vertical-align: middle;">${users.Rep}</span>&nbsp<img src="Image/Estrella.png" style="width:25px;heigth:25px;" ></img><br><label style="">Joined </label><br>${users.FechaRegistro}`;
                for (i = 0; i < seguidos.length; i++) {
                    if (users.IDPerfil == seguidos[i]) {
                        BotonPerfil.innerHTML = `<input class="btn btn-outline-danger col-12" onclick="noseguir(${users.IDPerfil})" type="button" value="Dejar de Seguir"></input>`;
                        band = 1;
                    }
                    if (band == 0) 
                    {
                        BotonPerfil.innerHTML = `<input class="btn btn-outline-primary col-12" onclick="seguir(${users.IDPerfil})" type="button" value="Seguir"></input>`;
                    }
                }
                if (seguidos.length == 0) {
                    BotonPerfil.innerHTML = `<input class="btn btn-outline-primary col-12" onclick="seguir(${users.IDPerfil})" type="button" value="Seguir"></input>`;
                }
            }
            )

            return Usuarios

        })

        .catch(error => console.error('Error:', error))
    await ConteoFollowers(id);
}


async function ConteoFollowers(idPerfil) {

    const Datos = { idPerfil }
    await fetch('Profile.aspx/ConteoFollowers', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Datos)

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


async function seguir(idFollowing) {
    const Datos = { idFollowing }
    await fetch('Buscador.aspx/seguir', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Datos)

    })
        .catch(error => console.error('Error:', error))

    await GetSeguidos(idFollowing);
    await DatosPerfil(idFollowing);
 

}

async function noseguir(idFollowing) {
    const Datos = { idFollowing }
    await fetch('Buscador.aspx/noseguir', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Datos)

    })
        .catch(error => console.error('Error:', error))
 
    await GetSeguidos(idFollowing);
    await DatosPerfil(idFollowing);
}