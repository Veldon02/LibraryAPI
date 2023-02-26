using Domain.Common.Errors;
using Domain.Entities.BookEntity;
using MediatR;
using OneOf;

namespace Application.Books.Queries.GetBookDetails
{
    public record GetBookDetailsQuery(int Id) : IRequest<OneOf<Book, IError>>;
}
