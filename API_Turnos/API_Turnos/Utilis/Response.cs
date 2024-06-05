namespace API_Turnos.Utilis
{
    public class Response<T>
    {
        public bool State { get; set; }
        public T Vaule { get; set; }
        public string? Mesagge { get; set; }
    }
}
