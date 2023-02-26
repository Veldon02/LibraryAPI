using Domain.Common.Errors;
using Domain.Entities.BookEntity;
using MediatR;
using OneOf;

namespace Application.Books.Queries.GetBooksOrderBy
{
    public record GetBooksOrderByQuery(string Property) : IRequest<OneOf<List<Book>, IError>>;
}
