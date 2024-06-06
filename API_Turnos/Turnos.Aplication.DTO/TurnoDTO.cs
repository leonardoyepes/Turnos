namespace Turnos.Aplication.DTO
{
    public class TurnoDTO
    {
        public long IdTurno { get; set; }

        public int IdServicio { get; set; }

        public string FechaTurno { get; set; } = null!;

        public string HoraInicio { get; set; } = null!;

        public string HoraFin { get; set; } = null!;

        public bool Estado { get; set; }

        public virtual ServicioDTO IdServicioNavigation { get; set; } = null!;
    }

    public class GenerarTurnosDTO
    {
        public int IdServicio { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }
}
