using System;
using System.Collections.Generic;

namespace diabeWeb.Models;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string? NombrePac { get; set; }

    public string? ApellidoPac { get; set; }

    public int? Edad { get; set; }

    public float? Peso { get; set; }

    public float? Altura { get; set; }

    public string? Dni { get; set; }

    public string? Email { get; set; }

    public string? Localidad { get; set; }
}
