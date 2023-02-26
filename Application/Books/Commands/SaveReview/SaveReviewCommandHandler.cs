using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entities;
using MediatR;
using OneOf;

namespace Application.Books.Commands.SaveReview
{
    public class SaveReviewCommandHandler : IRequestHandler<SaveReviewCommand, OneOf<Review, IError>>
    {
        private readonly IBookRepository _bookRepository;
        public SaveReviewCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<OneOf<Review, IError>> Handle(SaveReviewCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null) return new BookNotFoundError();
            var review = new Review()
            {
                Message = request.Message,
                Reviewer = request.Reviewer
            };

            book.Reviews.Add(review);

            await _bookRepository.UpdateAsync(book);

            return review;
        }
    }
}
