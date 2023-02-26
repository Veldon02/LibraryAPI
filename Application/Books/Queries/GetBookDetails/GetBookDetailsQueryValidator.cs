using FluentValidation;

namespace Application.Books.Queries.GetBookDetails
{
    public class GetBookDetailsQueryValidator : AbstractValidator<GetBookDetailsQuery>
    {
        public GetBookDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
