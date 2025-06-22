﻿using System;
using System.Collections.Generic;

namespace Lab05_RoyChuchullo.Models;

public partial class Curso
{
    public int IdCurso { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Creditos { get; set; }

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual ICollection<Evaluacione> Evaluaciones { get; set; } = new List<Evaluacione>();

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
