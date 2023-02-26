using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entities.BookEntity;
using MediatR;
using OneOf;
using System.Net.Http.Headers;

namespace Application.Books.Commands.SaveBook
{
    public class SaveBookCommandHandler : IRequestHandler<SaveBookCommand, OneOf<Book, IError>>
    {
        private readonly IBookRepository _bookRepository;
        public SaveBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<OneOf<Book, IError>> Handle(SaveBookCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                var book = new Book()
                {
                    Title = request.Title,
                    Content = request.Content,
                    Author = request.Author,
                    Cover = request.Cover,
                    Genre = request.Genre.ToLower(),
                };
                book = await _bookRepository.AddAsync(book);
                return book;
            }
            else
            {
                var book = await _bookRepository.GetByIdAsync((int)request.Id);
                if (book == null) return new BookNotFoundError();

                book.Title = request.Title;
                book.Content = request.Content;
                book.Author = request.Author;
                book.Cover = request.Cover;
                book.Genre = request.Genre;

                await _bookRepository.UpdateAsync(book);

                return book;
            }

        }
    }
}
