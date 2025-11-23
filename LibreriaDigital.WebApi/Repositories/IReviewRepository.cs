using LibreriaDigital.WebApi.Models;

namespace LibreriaDigital.WebApi.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetByBookAsync(int bookId);
        Task<IEnumerable<Review>> GetByUserAsync(int userId);
        Task<Review> CreateAsync(Review review);
        Task<Review?> UpdateAsync(Review review);
        Task<bool> DeleteAsync(int id);
    }
}
