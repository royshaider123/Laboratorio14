using System;
using System.Collections.Generic;

namespace Lab05_RoyChuchullo.Models;

public partial class Profesore
{
    public int IdProfesor { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Especialidad { get; set; }

    public string? Correo { get; set; }
}
