namespace LibreriaDigital.WebApi.DTOs.BookDtos
{
    public class UpdateBookDto
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnioPublicacion { get; set; }
        public string? ImagenPortada { get; set; }
    }
}
