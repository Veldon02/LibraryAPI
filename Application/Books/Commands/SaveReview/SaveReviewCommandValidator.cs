using FluentValidation;

namespace Application.Books.Commands.SaveReview
{
    public class SaveReviewCommandValidator : AbstractValidator<SaveReviewCommand>
    {
        public SaveReviewCommandValidator()
        {
            RuleFor(x => x.BookId).NotEmpty();
            RuleFor(x => x.Message).NotEmpty();
            RuleFor(x => x.Reviewer).NotEmpty();
        }
    }
}
