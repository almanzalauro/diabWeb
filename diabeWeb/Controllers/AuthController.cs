using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using MySqlConnector;
using diabeWeb.Models;
using Microsoft.AspNetCore.Authentication;

namespace diabeWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login(string email, string contraseña)
        {
            // Obtener la cadena de conexión a la base de datos
            string connectionString = _configuration.GetConnectionString("conexion");

            // Realizar la validación del usuario
            Paciente paciente = null;

            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                //abro la conexion
                connection.Open();
                //hago una consulta para traer todos los usuarios (email y dni)
                string query = "SELECT * FROM Pacientes WHERE Email = @Email AND Dni = @Contraseña";
                //mando la consulta a la base de datos
                using var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Contraseña", contraseña);

                using var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    paciente = new Paciente
                    {
                        Email = reader.GetString("Email"),
                        Dni = reader.GetString("Dni")
                    };
                }
            }

            if (paciente != null)
            {
                // Usuario válido, realizar el proceso de inicio de sesión
                // Redirigir a la página principal u otra página según tu lógica
                return RedirectToAction("PacienteHome", "Home");
            }
            else
            {

                // Usuario no válido, no se encuentra en la base de datos
                //redirijo a la pestaña de login
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Logout()
        {
            // Realizar aquí cualquier lógica adicional antes de cerrar sesión, si es necesario

            // Limpiar la información de autenticación del usuario actual
            HttpContext.SignOutAsync();

            // Redirigir a la página de inicio u otra página según tu lógica
            return RedirectToAction("Index", "Home");
        }


    }
}
