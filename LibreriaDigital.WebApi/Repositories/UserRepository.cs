using LibreriaDigital.WebApi.Data;
using LibreriaDigital.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibreriaDigital.WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibreriaContext _context;

        public UserRepository(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null) return null;

            existingUser.Nombre = user.Nombre;
            existingUser.Apellido = user.Apellido;
            existingUser.Correo = user.Correo;
            existingUser.Contrasena = user.Contrasena;

            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
