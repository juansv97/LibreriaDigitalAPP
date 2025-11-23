namespace LibreriaDigital.WebApi.DTOs.BookDtos
{
    public class CreateBookDto
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnioPublicacion { get; set; }
        public string? ImagenPortada { get; set; }

        // El dueño del libro
        public int UserId { get; set; }
    }
}
