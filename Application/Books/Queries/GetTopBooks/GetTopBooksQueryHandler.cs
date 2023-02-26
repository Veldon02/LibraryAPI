using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entities.BookEntity;
using MediatR;
using OneOf;

namespace Application.Books.Queries.GetTopBooks
{
    public class GetTopBooksQueryHandler : IRequestHandler<GetTopBooksQuery, OneOf<List<Book>, IError>>
    {
        private readonly IBookRepository _bookRepository;

        public GetTopBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<OneOf<List<Book>, IError>> Handle(GetTopBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetTopBooks(request.Count, request.Genre);

            if (books.Count == 0) return new NoBooksGenreError();

            return books;
        }
    }
}
