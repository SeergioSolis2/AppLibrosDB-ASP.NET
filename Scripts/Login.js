
const Usuario = document.querySelector('#Usuario');
const Contrasena = document.querySelector('#Password');


const ModalNombre = document.querySelector("#ModalNombre");
const ModalApellido_P = document.querySelector("#Apellido_Paterno")
const ModalApellido_M = document.querySelector("#Apellido_Materno");
const ModalSexo = document.querySelector("#Sexo");
const ModalNacionalidad = document.querySelector("#Nacionalidad");
const ModalFecha_Nac = document.querySelector("#F_Nac");
const ModalUser = document.querySelector("#user");
const ModalEmail = document.querySelector("#Email");
const ModalPassword=document.querySelector("#pass")



document.addEventListener("DOMContentLoaded", async function (event) {

   

})


async function ValidarLogin() {

    var Username = Usuario.value;
    var password = Contrasena.value;
    const Datos = {Username,password}
    console.log(Datos);
    await fetch('Login.aspx/Login', {
        
        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Datos)
    })
        .then(response => response.json())
        .then(data => {
           const Usuarios=JSON.parse(data.d)
            console.log(Usuarios)
            if (Usuarios.length > 0) {
                window.location.href = "/Profile.aspx";
            } else {
               
            }

            return Usuarios
       
        })
  
        .catch(error => console.error('Error:', error))
}




async function Registro() {

    var Nombres =ModalNombre.value;
    var Apellido_P = ModalApellido_P.value;
    var Apellido_M = ModalApellido_M.value;
    var Sexo = ModalSexo.value;
    var Nacionalidad = ModalNacionalidad.value;
    var FNac = ModalFecha_Nac.value;
    var Usuario = ModalUser.value;
    var Email = ModalEmail.value;
    var Contrasena = ModalPassword.value;
    const Datos = { Nombres, Apellido_P,Apellido_M,Sexo,Nacionalidad,FNac,Usuario,Email,Contrasena }
    console.log(Datos);
    await fetch('Login.aspx/Registro', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Datos)
    })
   .catch(error => console.error('Error:', error))
}