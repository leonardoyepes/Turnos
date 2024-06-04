using System;
using System.Collections.Generic;

namespace Turnos.Domain.Model;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public int IdComercio { get; set; }

    public string NomServicio { get; set; } = null!;

    public DateTime HoraApertura { get; set; }

    public DateTime HoraCierre { get; set; }

    public int Duracion { get; set; }

    public virtual Comercio IdComercioNavigation { get; set; } = null!;

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
