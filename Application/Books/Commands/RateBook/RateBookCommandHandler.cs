using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entities;
using MediatR;
using OneOf;

namespace Application.Books.Commands.RateBook
{
    public class RateBookCommandHandler : IRequestHandler<RateBookCommand, OneOf<Rating, IError>>
    {
        private readonly IBookRepository _bookRepository;
        public RateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<OneOf<Rating, IError>> Handle(RateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null) return new BookNotFoundError();

            var rating = new Rating()
            {
                Score = request.Score
            };

            book.Ratings.Add(rating);

            await _bookRepository.UpdateAsync(book);

            return rating;
        }
    }
}
