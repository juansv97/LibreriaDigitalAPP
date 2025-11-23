namespace LibreriaDigital.WebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int AnioPublicacion { get; set; }
        public string? ImagenPortada { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
