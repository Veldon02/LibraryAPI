using Domain.Common.Errors;
using Domain.Entities;
using MediatR;
using OneOf;

namespace Application.Books.Commands.SaveReview
{
    public record SaveReviewCommand(
        int BookId,
        string Message,
        string Reviewer) :IRequest<OneOf<Review, IError>>;
}
