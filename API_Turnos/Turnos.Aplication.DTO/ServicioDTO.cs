namespace Turnos.Aplication.DTO
{
    public class ServicioDTO
    {
        public int IdServicio { get; set; }

        public int IdComercio { get; set; }

        public string NomServicio { get; set; } = null!;

        public DateTime HoraApertura { get; set; }

        public DateTime HoraCierre { get; set; }

        public int Duracion { get; set; }

        public virtual ComercioDTO IdComercioNavigation { get; set; } = null!;

        public virtual ICollection<TurnoDTO> Turnos { get; set; } = new List<TurnoDTO>();
    }
}
