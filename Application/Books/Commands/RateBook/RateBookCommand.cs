using Domain.Common.Errors;
using Domain.Entities;
using MediatR;
using OneOf;

namespace Application.Books.Commands.RateBook
{
    public record RateBookCommand(
        int BookId,
        int Score) :IRequest<OneOf<Rating,IError>>;
}
