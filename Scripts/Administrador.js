const DivLibros = document.querySelector('#Tuslibros');
const ISBN = document.querySelector('#ModalISBN');
const Autor = document.querySelector('#ModalAutor');
const Titulo = document.querySelector('#ModalTitulo');
const Edicion = document.querySelector('#ModalEdicion');
const Editorial = document.querySelector('#ModalEditorial')
const Lugar = document.querySelector('#ModalLugar')
const Año = document.querySelector('#ModalAño')
const Paginas = document.querySelector('#ModalPaginas')
const Rating=document.querySelector('#ModalRating')
//INSERT INTO appdblibro.dbo.libros (ISBN,Autor,Titulo,Edicion,Lugar,Anio,Rating) values (,'','','','','',,,)
document.addEventListener("DOMContentLoaded", async function (event) {
    await Getlibros();
})

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