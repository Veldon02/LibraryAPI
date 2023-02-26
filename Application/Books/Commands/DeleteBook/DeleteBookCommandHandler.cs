using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entities.BookEntity;
using MediatR;
using OneOf;

namespace Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, OneOf<Book, IError>>
    {
        private readonly IBookRepository _bookRepository;
        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<OneOf<Book, IError>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null) return new BookNotFoundError();

            if (request.ProvidedKey != request.SecretKey) return new WrongSecretKeyError();

            await _bookRepository.RemoveAsync(book);

            return book;
        }
    }
}
