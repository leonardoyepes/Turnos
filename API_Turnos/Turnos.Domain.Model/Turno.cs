using System;
using System.Collections.Generic;

namespace Turnos.Domain.Model;

public partial class Turno
{
    public long IdTurno { get; set; }

    public int IdServicio { get; set; }

    public string FechaTurno { get; set; } = null!;

    public string HoraInicio { get; set; } = null!;

    public string HoraFin { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}
