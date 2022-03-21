////var contenedor = document.querySelector("#caja")
////var obtenerDatos = () => fetch("https://www.cultura.gob.ar/api/v2.0/museos/?format=json")
////obtenerDatos()
////    .then((datos) =>
////        datos.json()
////    )
////    .then((respuesta) => {
////        cargarDatos(respuesta[0])
////    })
var cargarDatos = (a) => {
    var { character, quote } = a
    var contenedor2 = document.createElement("div")
    var nombre = document.createElement("h1")
    var direccion = document.createElement("p")
    var descripcion = document.createElement("p")
    nombre.textContent = character
    nombre.className = "text-center text-danger"
    direccion.textContent = quote
    direccion.className = "text- center text-danger"
    descripcion.textContent = quote
    descripcion.className = "text-center text-danger"
    contenedor2.appendChild(nombre)
    contenedor2.appendChild(direccion)
    contenedor2.appendChild(descripcion)
    contenedor.appendChild(contenedor2)
}