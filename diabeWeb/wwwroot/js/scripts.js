function validateForm() {
    var username = document.getElementById("email").value;
    var password = document.getElementById("password").value;

    if (username === "" || password === "") {
        document.getElementById("error-message").innerText = "Por favor, completa los datos.";
        document.getElementById("error-message").style.display = "block";
        document.getElementById("error-message").style.color = "red";
        document.getElementById("error-message").style.fontWeight = "bold";
        return false;
    }
    return true;
}


// Obtener el botón por su ID
var boton = document.getElementById("crear-paciente");

// Agregar un event listener al botón para capturar el clic
boton.addEventListener("click", function (event) {
    //event.preventDefault(); // Evita que se envíe el formulario

    // Obtener el elemento del mensaje
    var mensaje = document.getElementById("mensaje-paciente-creado");
    // Mostrar el mensaje cambiando el estilo de visualización
    mensaje.style.visibility = "visible";
});


