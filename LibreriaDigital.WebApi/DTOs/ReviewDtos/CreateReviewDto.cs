namespace LibreriaDigital.WebApi.DTOs.ReviewDtos
{
    public class CreateReviewDto
    {
        public int Calificacion { get; set; } // 1-5
        public string Comentario { get; set; }

        public int UserId { get; set; } // Dueño del libro
        public int BookId { get; set; } // Libro asociado
    }
}
