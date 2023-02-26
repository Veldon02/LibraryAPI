using FluentValidation;

namespace Application.Books.Commands.SaveBook
{
    public class SaveBookCommandValidator : AbstractValidator<SaveBookCommand>
    {
        public SaveBookCommandValidator()
        {
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.Cover).NotEmpty();
            RuleFor(x => x.Genre).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
