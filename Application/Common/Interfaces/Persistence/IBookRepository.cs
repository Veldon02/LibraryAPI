using Domain.Entities.BookEntity;

namespace Application.Common.Interfaces.Persistence
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(int id);
        Task<Book> AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task RemoveAsync(Book book);
        Task<List<Book>> GetBooksOrderBy(string property);
        Task<List<Book>> GetTopBooks(int count, string genre);
    }
}
