using LibreriaDigital.WebApi.Data;
using LibreriaDigital.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibreriaDigital.WebApi.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly LibreriaContext _context;

        public ReviewRepository(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetByBookAsync(int bookId)
        {
            return await _context.Reviews
                .Include(r => r.User)
                .Where(r => r.BookId == bookId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetByUserAsync(int userId)
        {
            return await _context.Reviews
                .Include(r => r.Book)
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task<Review> CreateAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review?> UpdateAsync(Review review)
        {
            var existing = await _context.Reviews.FindAsync(review.Id);
            if (existing == null) return null;

            existing.Calificacion = review.Calificacion;
            existing.Comentario = review.Comentario;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return false;

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
