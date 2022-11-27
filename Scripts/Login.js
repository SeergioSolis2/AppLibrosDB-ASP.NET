
const Usuario = document.querySelector('#Usuario');
const Contrasena = document.querySelector('#Password');




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
