using LibreriaDigital.WebApi.DTOs.UserDtos;
using LibreriaDigital.WebApi.Models;
using LibreriaDigital.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaDigital.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repository.GetAllAsync();

            var response = users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                NombreCompleto = $"{u.Nombre} {u.Apellido}",
                Correo = u.Correo
            });

            return Ok(response);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            var response = new UserResponseDto
            {
                Id = user.Id,
                NombreCompleto = $"{user.Nombre} {user.Apellido}",
                Correo = user.Correo
            };

            return Ok(response);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var newUser = new User
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Correo = dto.Correo,
                Contrasena = dto.Contrasena
            };

            var created = await _repository.CreateAsync(newUser);

            var response = new UserResponseDto
            {
                Id = created.Id,
                NombreCompleto = $"{created.Nombre} {created.Apellido}",
                Correo = created.Correo
            };

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, response);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserDto dto)
        {
            var userToUpdate = new User
            {
                Id = id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Correo = dto.Correo,
                Contrasena = dto.Contrasena
            };

            var updated = await _repository.UpdateAsync(userToUpdate);
            if (updated == null)
                return NotFound();

            var response = new UserResponseDto
            {
                Id = updated.Id,
                NombreCompleto = $"{updated.Nombre} {updated.Apellido}",
                Correo = updated.Correo
            };

            return Ok(response);
        }

        // DELETE: api/Users/5
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
