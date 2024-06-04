using System;
using System.Collections.Generic;

namespace Turnos.Domain.Model;

public partial class Comercio
{
    public int IdComercio { get; set; }

    public string NomComercio { get; set; } = null!;

    public long AforoMaximo { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
