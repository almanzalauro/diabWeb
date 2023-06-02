using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using MySqlConnector;
using diabeWeb.Models;

namespace TuProyecto.Controllers
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
                connection.Open();

                string query = "SELECT * FROM Pacientes WHERE Email = @Email AND Dni = @Contraseña";
                using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            paciente = new Paciente
                            {
                                Email = reader.GetString("Email"),
                                Dni = reader.GetString("Dni")
                            };
                        }
                    }
                }
            }

            if (paciente != null)
            {
                // Usuario válido, realizar el proceso de inicio de sesión
                // Redirigir a la página principal u otra página según tu lógica
                return RedirectToAction("Index", "Pacientes");
            }
            else
            {

                // Usuario no válido, mostrar mensaje de error o redirigir a la página de error de inicio de sesión
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
