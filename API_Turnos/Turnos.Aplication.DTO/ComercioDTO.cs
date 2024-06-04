namespace Turnos.Aplication.DTO
{
    public class ComercioDTO
    {
        public int IdComercio { get; set; }

        public string NomComercio { get; set; } = null!;

        public long AforoMaximo { get; set; }

        public virtual ICollection<ServicioDTO> Servicios { get; set; } = new List<ServicioDTO>();
    }
}
