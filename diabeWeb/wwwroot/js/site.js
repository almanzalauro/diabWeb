// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const validarUsuario = () => {
    var correo = document.querySelector("#correo").value;
    var passw = document.querySelector("#contraseña").value;

    if (correo.trim() == '' || passw.trim() == '') {
        alert("Campos vacios");
    }
    
}






//---Funciones de validacion----
