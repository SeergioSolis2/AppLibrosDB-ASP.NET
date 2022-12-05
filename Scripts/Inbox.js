const UserDiv = document.querySelector("#Perfilesmsg");
const messageDiv = document.querySelector("#messages");
let identificadorIntervaloDeTiempo;
var lista = new Array();

document.addEventListener("DOMContentLoaded", async function (event) {
    cargarPerfiles()
    console.log("Hola")
})

async function cargarPerfiles() {
    await fetch('Inbox.aspx/cargarperfiles', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },

    })
        .then(response => response.json())
        .then(data => {
            const perfiles = JSON.parse(data.d)
            console.log(perfiles)
            perfiles.forEach(Perfil => {
                var l2 = document.createElement("input")
                l2.setAttribute("type", "text")
                l2.setAttribute("id", "aidi")
                l2.setAttribute("hidden", "true")
                l2.setAttribute("value", Perfil.IDPerfil)
                messageDiv.appendChild(l2);
                console.log(Perfil)
                var a = document.createElement("a")
                var br = document.createElement("br")
                a.setAttribute("id", Perfil.IDPerfil)
                a.setAttribute("onclick", "loop(" + Perfil.IDPerfil + ")")
                console.log(Perfil.Usuario)
                a.innerHTML = `${Perfil.Usuario}`
                a.appendChild(br)
                UserDiv.appendChild(a)
                
            })
            return perfiles;
        })

        .catch(error => console.error('Error:', error))
}

function loop(IDPerfil) {
    detener()
    lista = new Array();
    messageDiv.innerHTML = ''
    var l2 = document.createElement("input")
    l2.setAttribute("type", "text")
    l2.setAttribute("id", "aidi")
    l2.setAttribute("hidden", "true")
    l2.setAttribute("value", IDPerfil)
    messageDiv.appendChild(l2);
    document.getElementById("aidi").value = IDPerfil
    identificadorIntervaloDeTiempo = setInterval(function () { cargarMensajes(IDPerfil);},500)
}

function detener() {
    clearInterval(identificadorIntervaloDeTiempo)
}

async function agregarMensajes() {
    const Destinatario = document.getElementById("aidi").value;
    const msg = document.getElementById("msg").value;
    console.log(Destinatario)
    const datos = { Destinatario , msg }
    await fetch('Inbox.aspx/agregarmensaje', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(datos)
    })
}
function cargarMensajes(IDPerfil) {
    
    /*var l = document.createElement("input")*/
    /*var l3 = document.createElement("input")
    var x = document.createElement("div")*/

    /*l.setAttribute("id", "msg")
    l.setAttribute("type", "text")*/



    /*l3.setAttribute("value", "Enviar")
    l3.setAttribute("type", "button")
    l3.setAttribute("onclick", "agregarMensajes()")*/

    /*/x.setAttribute("class", "btn-holder")

    x.appendChild(l);
    x.appendChild(l3);*/
    /*messageDiv.appendChild(x);*/

    peticionmsg(IDPerfil);

}

function peticionmsg(IDPerfil) {
    var Destinatario = IDPerfil;
    const datos = { Destinatario }
    var temp = [];
    fetch('Inbox.aspx/cargarmsg', {

            method: 'POST', // or 'PUT'
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(datos),

        })
        .then(response => response.json())
        .then(data => {
            const mensaje = JSON.parse(data.d)
            var a = document.createElement("div")
            var p = document.createElement("p")
            var span = document.createElement("span")
            mensaje.forEach(mensajes => {

                if (mensajes.Destinatario == IDPerfil) {
                    a.setAttribute("class", "container")
                    p.innerHTML = mensajes.msg
                    span.setAttribute("class", "time-left")
                    temp.push(mensajes)
                }
                else {
                    a.setAttribute("class", "container darker")
                    p.innerHTML = mensajes.msg
                    span.setAttribute("class", "time-right")
                    temp.push(mensajes)
                }
            }
            )
            if (typeof lista[0] == 'undefined') {
                lista.push(temp);
                lista[0].forEach(mensajes => {
                    var dib = document.createElement("div")
                    var para = document.createElement("p")
                    var span1 = document.createElement("span")
                    if (mensajes.Destinatario == IDPerfil) {
                        dib.setAttribute("class", "container")
                        para.innerHTML = mensajes.msg
                        span1.setAttribute("class", "time-left")
                    } else {
                        dib.setAttribute("class", "container darker")
                        para.innerHTML = mensajes.msg
                        span1.setAttribute("class", "time-right")
                    }
                    dib.appendChild(p)
                    dib.appendChild(span)
                    dib.innerHTML = `${mensajes.msg}`
                    messageDiv.appendChild(dib)
                })
            }
            if (temp.length > lista[0].length) {
                lista[0].push(temp[temp.length - 1])
                a.appendChild(p)
                a.appendChild(span)
                messageDiv.appendChild(a)
                document.getElementById("msg").value = ''
            }
            
            return mensaje;

        })

        .catch(error => console.error('Error:', error))
}