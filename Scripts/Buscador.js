const SelectBuscar = document.querySelector("#Buscador");
document.addEventListener("DOMContentLoaded", async function (event) {
    $('#Buscador').select2();
    await llenarBuscador();
})

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
                var Option=document.createElement('option')
                Option.value=Usuario.Nombres
                Option.textContent = Usuario.Nombres
                SelectBuscar.appendChild(Option)

            }
            )

         

        })

        .catch(error => console.error('Error:', error))
}