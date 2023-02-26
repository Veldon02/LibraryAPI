using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entities.BookEntity;
using MediatR;
using OneOf;
using System.Net;

namespace Application.Books.Queries.GetBooksOrderBy
{
    public class GetBooksOerderByQueryHandler : IRequestHandler<GetBooksOrderByQuery, OneOf<List<Book>, IError>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksOerderByQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<OneOf<List<Book>, IError>> Handle(GetBooksOrderByQuery request, CancellationToken cancellationToken)
        {
            if (request.Property != "author" && request.Property != "title")
                return new InvalidPropertyNameError();

            return await _bookRepository.GetBooksOrderBy(request.Property);
        }
    }
}
