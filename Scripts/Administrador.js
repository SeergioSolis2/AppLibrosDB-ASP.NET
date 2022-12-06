const DivLibros = document.querySelector('#Tuslibros');
const ISBN = document.querySelector('#ModalISBN');
const Autor = document.querySelector('#ModalAutor');
const Titulo = document.querySelector('#ModalTitulo');
const Edicion = document.querySelector('#ModalEdicion');
const Editorial = document.querySelector('#ModalEditorial')
const Lugar = document.querySelector('#ModalLugar')
const Año = document.querySelector('#ModalAño')
const Paginas = document.querySelector('#ModalPaginas')
const Rating = document.querySelector('#ModalRating')
const tabla1 = document.querySelector('#reporte1')
const tabla2 = document.querySelector('#reporte2')
const tabla3 = document.querySelector('#reporte3')
const tabla4 = document.querySelector('#reporte4')
const tabla5= document.querySelector('#reporte5')
const tabla6= document.querySelector('#reporte6')
const tabla7= document.querySelector('#reporte7')
const tabla8= document.querySelector('#reporte8')
const tabla9= document.querySelector('#reporte9')
const tabla10 = document.querySelector('#reporte10')
const tablausuario = document.querySelector('#tablausuario')

//INSERT INTO appdblibro.dbo.libros (ISBN,Autor,Titulo,Edicion,Lugar,Anio,Rating) values (,'','','','','',,,)
document.addEventListener("DOMContentLoaded", async function (event) {
    await Getlibros();
    await Reporte1();
    await Reporte2();
    await Reporte3();
    await Reporte4();
    await Reporte5();
    await Reporte6();
    await Reporte7();
    await Reporte8();
    await Reporte9();
    await Reporte10();
    await GetUsuarios();
})


async function GetUsuarios() {
    await fetch('Administrador.aspx/GetUsuarios', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },


    })

        .then(response => response.json())
        .then(data => {
            const Filas = JSON.parse(data.d)

            Filas.forEach(Fila => {
                var tr = document.createElement("tr");

                tr.innerHTML = `
                     <td>${Fila.Fila1}</td>
                     <td>${Fila.Fila2}</td>
                     <td>${Fila.Fila3}</td>`


                tablausuario.appendChild(tr);
            }
            )



        })

        .catch(error => console.error('Error:', error))
}


async function Reporte1() {

    await fetch('Administrador.aspx/Reporte1', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },


    })

        .then(response => response.json())
        .then(data => {
            const Filas = JSON.parse(data.d)

            Filas.forEach(Fila => {
                var tr = document.createElement("tr");

                tr.innerHTML = `
                     <td>${Fila.Fila1}</td>
                     <td>${Fila.Fila2}</td>
                     <td>${Fila.Fila3}</td>`
                  

                tabla1.appendChild(tr);
            }
            )



        })

        .catch(error => console.error('Error:', error))
}




async function Reporte2() {

    await fetch('Administrador.aspx/Reporte2', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },


    })

        .then(response => response.json())
        .then(data => {
            const Filas = JSON.parse(data.d)

            Filas.forEach(Fila => {
                var tr = document.createElement("tr");

                tr.innerHTML = `
                     <td>${Fila.Fila1}</td>
                     <td>${Fila.Fila2}</td>
                     <td>${Fila.Fila3}</td>`


                tabla2.appendChild(tr);
            }
            )



        })

        .catch(error => console.error('Error:', error))
}


async function Reporte3() {

    await fetch('Administrador.aspx/Reporte3', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },


    })

        .then(response => response.json())
        .then(data => {
            const Filas = JSON.parse(data.d)

            Filas.forEach(Fila => {
                var tr = document.createElement("tr");

                tr.innerHTML = `
                     <td>${Fila.Fila1}</td>
                     <td>${Fila.Fila2}</td>
                     `


                tabla3.appendChild(tr);
            }
            )



        })

        .catch(error => console.error('Error:', error))
}

async function Reporte4() {

    await fetch('Administrador.aspx/Reporte4', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },


    })

        .then(response => response.json())
        .then(data => {
            const Filas = JSON.parse(data.d)

            Filas.forEach(Fila => {
                var tr = document.createElement("tr");

                tr.innerHTML = `
                     <td>${Fila.Fila1}</td>
                     <td>${Fila.Fila2}</td>
                     `


                tabla4.appendChild(tr);
            }
            )



        })

        .catch(error => console.error('Error:', error))
}



async function Reporte5() {

    await fetch('Administrador.aspx/Reporte5', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },


    })

        .then(response => response.json())
        .then(data => {
            const Filas = JSON.parse(data.d)

            Filas.forEach(Fila => {
                var tr = document.createElement("tr");

                tr.innerHTML = `
                     <td>${Fila.Fila1}</td>
                     <td>${Fila.Fila2}</td>
                     `


                tabla5.appendChild(tr);
            }
            )



        })

        .catch(error => console.error('Error:', error))
}

async function Reporte6() {

    await fetch('Administrador.aspx/Reporte6', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },


    })

        .then(response => response.json())
        .then(data => {
            const Filas = JSON.parse(data.d)

            Filas.forEach(Fila => {
                var tr = document.createElement("tr");

                tr.innerHTML = `
                     <td>${Fila.Fila1}</td>
                     <td>${Fila.Fila2}</td>
                     <td>${Fila.Fila3}</td>
                     `


                tabla6.appendChild(tr);
            }
            )



        })

        .catch(error => console.error('Error:', error))
}



async function Reporte7() {

    await fetch('Administrador.aspx/Reporte7', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },


    })

        .then(response => response.json())
        .then(data => {
            const Filas = JSON.parse(data.d)

            Filas.forEach(Fila => {
                var tr = document.createElement("tr");

                tr.innerHTML = `
                     <td>${Fila.Fila1}</td>
                     <td>${Fila.Fila2}</td>
             
                     `


                tabla7.appendChild(tr);
            }
            )



        })

        .catch(error => console.error('Error:', error))
}




async function Reporte8() {

    await fetch('Administrador.aspx/Reporte8', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },


    })

        .then(response => response.json())
        .then(data => {
            const Filas = JSON.parse(data.d)

            Filas.forEach(Fila => {
                var tr = document.createElement("tr");

                tr.innerHTML = `
                     <td>${Fila.Fila1}</td>
                     <td>${Fila.Fila2}</td>
             
                     `


                tabla8.appendChild(tr);
            }
            )



        })

        .catch(error => console.error('Error:', error))
}



async function Reporte9() {

    await fetch('Administrador.aspx/Reporte9', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },


    })

        .then(response => response.json())
        .then(data => {
            const Filas = JSON.parse(data.d)

            Filas.forEach(Fila => {
                var tr = document.createElement("tr");

                tr.innerHTML = `
                     <td>${Fila.Fila1}</td>
                     <td>${Fila.Fila2}</td>
             
                     `


                tabla9.appendChild(tr);
            }
            )



        })

        .catch(error => console.error('Error:', error))
}

async function Reporte10() {

    await fetch('Administrador.aspx/ReporteFinal', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },


    })

        .then(response => response.json())
        .then(data => {
            const Filas = JSON.parse(data.d)

            Filas.forEach(Fila => {
                var tr = document.createElement("tr");

                tr.innerHTML = `
                     <td>${Fila.Fila1}</td>
                     <td>${Fila.Fila2}</td>
             
                     `


                tabla10.appendChild(tr);
            }
            )



        })

        .catch(error => console.error('Error:', error))
}


async function NewLibro() {
  var isbn=ISBN.value 
  var autor=Autor.value 
  var titulo= Titulo.value
  var edicion=Edicion.value 
  var editorial= Editorial.value
  var lugar=Lugar.value 
  var año = Año.value
  var paginas=Paginas.value 
  var rating = Rating.value


    if (isbn == '' || autor == '' || titulo == '' || edicion == '' || editorial == '' || lugar == '' || año == '' || paginas == '' || rating == '') {
        swal.fire("Faltan campos",'','error')
    }

    const Datos = {isbn,autor,titulo,edicion,editorial,lugar,año,paginas,rating}

    await fetch('Administrador.aspx/InsertLibro', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(Datos)

    })
    .catch(error => console.error('Error:', error))
    await Getlibros();
}



async function Getlibros(){
    DivLibros.innerHTML = "";

    await fetch('Administrador.aspx/Getlibros', {

        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },


    })

        .then(response => response.json())
        .then(data => {
            const Libros = JSON.parse(data.d)
            console.log(Libros)
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
                     <td>
                    
                    <input type="button" value="Eliminar" class="btn-danger" onclick="EliminarLibro(${libro.ISBN})"/></td>`

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
            await fetch('Administrador.aspx/EliminarLibro', {

                method: 'POST', // or 'PUT'
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(Datos)

            })

            await Getlibros();
        }
    })
    
 

}