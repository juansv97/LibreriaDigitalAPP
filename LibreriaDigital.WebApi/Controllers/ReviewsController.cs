using LibreriaDigital.WebApi.DTOs.ReviewDtos;
using LibreriaDigital.WebApi.Models;
using LibreriaDigital.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaDigital.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _repository;

        public ReviewsController(IReviewRepository repository)
        {
            _repository = repository;
        }

        // Obtener todas las reseñas de un libro
        [HttpGet("book/{bookId}")]
        public async Task<IActionResult> GetByBook(int bookId)
        {
            var reviews = await _repository.GetByBookAsync(bookId);
            return Ok(reviews);
        }

        // Obtener todas las reseñas hechas por un usuario
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var reviews = await _repository.GetByUserAsync(userId);
            return Ok(reviews);
        }

        // Crear una nueva reseña
        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewDto dto)
        {
            if (dto.Calificacion < 1 || dto.Calificacion > 5)
                return BadRequest("La calificación debe estar entre 1 y 5.");

            var newReview = new Review
            {
                Calificacion = dto.Calificacion,
                Comentario = dto.Comentario,
                BookId = dto.BookId,
                UserId = dto.UserId
            };

            var created = await _repository.CreateAsync(newReview);
            return CreatedAtAction(nameof(GetByBook), new { bookId = created.BookId }, created);
        }

        // Actualizar una reseña existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateReviewDto dto)
        {
            var reviewToUpdate = new Review
            {
                Id = id,
                Calificacion = dto.Calificacion,
                Comentario = dto.Comentario,
                BookId = dto.BookId,
                UserId = dto.UserId
            };

            var updated = await _repository.UpdateAsync(reviewToUpdate);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // Eliminar una reseña
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
