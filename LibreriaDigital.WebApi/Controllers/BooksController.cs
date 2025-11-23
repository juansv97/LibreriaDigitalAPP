using LibreriaDigital.WebApi.DTOs.BookDtos;
using LibreriaDigital.WebApi.Models;
using LibreriaDigital.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaDigital.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _repository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto dto)
        {
            var newBook = new Book
            {
                Titulo = dto.Titulo,
                Autor = dto.Autor,
                AnioPublicacion = dto.AnioPublicacion,
                ImagenPortada = dto.ImagenPortada,
                UserId = dto.UserId
            };

            var created = await _repository.CreateAsync(newBook);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookDto dto)
        {
            var bookToUpdate = new Book
            {
                Id = id,
                Titulo = dto.Titulo,
                Autor = dto.Autor,
                AnioPublicacion = dto.AnioPublicacion,
                ImagenPortada = dto.ImagenPortada
            };

            var updated = await _repository.UpdateAsync(bookToUpdate);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
