using FluentValidation;

namespace Application.Books.Queries.GetBooksOrderBy
{
    public class GetBooksOrderByQueryValidator : AbstractValidator<GetBooksOrderByQuery>
    {
        public GetBooksOrderByQueryValidator()
        {
            RuleFor(x => x.Property).NotEmpty();
        }
    }
}
