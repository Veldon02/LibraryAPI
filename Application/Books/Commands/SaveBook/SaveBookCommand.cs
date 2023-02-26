using Domain.Common.Errors;
using Domain.Entities.BookEntity;
using MediatR;
using OneOf;

namespace Application.Books.Commands.SaveBook
{
    public record SaveBookCommand(
        int? Id,
        string Title,
        string Cover,
        string Content,
        string Genre,
        string Author) : IRequest<OneOf<Book,IError>>;
}
