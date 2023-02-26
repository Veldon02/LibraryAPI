using Domain.Common.Errors;
using Domain.Entities.BookEntity;
using MediatR;
using OneOf;

namespace Application.Books.Queries.GetTopBooks
{
    public record GetTopBooksQuery(
        int Count,
        string? Genre) : IRequest<OneOf<List<Book>,IError>>;
}
