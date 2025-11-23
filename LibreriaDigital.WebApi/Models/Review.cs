namespace LibreriaDigital.WebApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Calificacion { get; set; } // 1-5
        public string Comentario { get; set; } = string.Empty;

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
