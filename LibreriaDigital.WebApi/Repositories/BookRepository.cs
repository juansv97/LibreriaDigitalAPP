using LibreriaDigital.WebApi.Data;
using LibreriaDigital.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibreriaDigital.WebApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibreriaContext _context;

        public BookRepository(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.Include(b => b.User).ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.Include(b => b.User)
                                       .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> UpdateAsync(Book book)
        {
            var existing = await _context.Books.FindAsync(book.Id);
            if (existing == null) return null;

            existing.Titulo = book.Titulo;
            existing.Autor = book.Autor;
            existing.AnioPublicacion = book.AnioPublicacion;
            existing.ImagenPortada = book.ImagenPortada;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
