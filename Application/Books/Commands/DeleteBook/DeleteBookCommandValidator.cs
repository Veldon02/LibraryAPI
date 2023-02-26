using FluentValidation;
using FluentValidation.Validators;

namespace Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ProvidedKey).NotEmpty();
        }   
    }
}
