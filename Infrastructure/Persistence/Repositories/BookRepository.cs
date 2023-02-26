using Application.Books.Queries.GetBooksOrderBy;
using Application.Common.Interfaces.Persistence;
using Domain.Entities.BookEntity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<Book> AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<List<Book>> GetBooksOrderBy(string property)
        {
            if (property == "author")
                 return await _context.Books
                    .OrderBy(x => x.Author)
                    .ToListAsync();
            else
                return await _context.Books
                    .OrderBy(x => x.Title)
                    .ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task RemoveAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetTopBooks(int count, string? genre)
        {
            IQueryable<Book> books = _context.Books;
            if (genre != null) books = books.Where(x => x.Genre == genre.ToLower());
            var bookList = await books.ToListAsync();

            return bookList.Where(b => b.ReviewNumber > 10)
                .OrderByDescending(b => b.AverageRating)
                .Take(count)
                .ToList();
        }
    }
}
