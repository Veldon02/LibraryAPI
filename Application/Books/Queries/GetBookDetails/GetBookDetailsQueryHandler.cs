using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entities.BookEntity;
using MediatR;
using OneOf;

namespace Application.Books.Queries.GetBookDetails
{
    public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, OneOf<Book, IError>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookDetailsQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<OneOf<Book, IError>> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null) return new BookNotFoundError();

            return book;
        }
    }
}
