using FluentValidation;

namespace Application.Books.Queries.GetTopBooks
{
    public class GetTopBooksQueryValidator : AbstractValidator<GetTopBooksQuery>
    {
        public GetTopBooksQueryValidator()
        {
            RuleFor(x => x.Count).GreaterThan(0);
        }
    }
}
