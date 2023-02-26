using FluentValidation;
using FluentValidation.Validators;

namespace Application.Books.Commands.RateBook
{
    public class RateBookCommandValidator : AbstractValidator<RateBookCommand>
    {
        public RateBookCommandValidator()
        {
            RuleFor(x => x.BookId).NotEmpty();
            RuleFor(x => x.Score).GreaterThanOrEqualTo(1).LessThanOrEqualTo(5);
        }
    }
}
