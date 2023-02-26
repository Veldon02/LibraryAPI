using Domain.Common.Errors;
using Domain.Entities.BookEntity;
using MediatR;
using OneOf;

namespace Application.Books.Commands.DeleteBook
{
    public record DeleteBookCommand(
        int Id,
        string ProvidedKey,
        string SecretKey) : IRequest<OneOf<Book,IError>>;
}
