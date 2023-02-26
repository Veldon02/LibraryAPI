using Api.Contracts.Common;
using Api.Contracts.DeleteBook;
using Api.Contracts.GetBooksOrderBy;
using Api.Contracts.GetTopBooks;
using Api.Contracts.RateBook;
using Api.Contracts.SaveBook;
using Api.Contracts.SaveReview;
using Application.Books.Commands.DeleteBook;
using Application.Books.Commands.RateBook;
using Application.Books.Commands.SaveBook;
using Application.Books.Commands.SaveReview;
using Application.Books.Queries.GetBookDetails;
using Application.Books.Queries.GetBooksOrderBy;
using Application.Books.Queries.GetTopBooks;
using Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    //private readonly string baseUrl = "localhost:5000";

    [Route("/api/[controller]")]
    public class BooksController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public BooksController(ISender mediator, IMapper mapper, IConfiguration configuration)
        {
            _mediator = mediator;
            _mapper = mapper;
            _configuration = configuration;
        }

        #region GET
        //Get all books. Order by provided value (title or author)
        [HttpGet]
        public async Task<ActionResult<List<BookResponse>>> GetBooksOrderBy([FromQuery] GetBooksOrderByRequest request)
        {
            var query = _mapper.Map<GetBooksOrderByQuery>(request);

            var result = await _mediator.Send(query);

            return result.Match(
                books => Ok(_mapper.Map<List<BookResponse>>(books)),
                error => Problem(error));
        }

        //Get top 10 books with high rating and number of reviews greater than 10. You can filter books by specifying genre. Order by rating
        [HttpGet("/recommended")]
        public async Task<ActionResult<List<BookResponse>>> GetTop10Books([FromQuery] GetTopBooksRequest request)
        {
            int count = 10;
            var query = _mapper.Map<GetTopBooksQuery>((count, request));

            var result = await _mediator.Send(query);

            return result.Match(
                books => Ok(_mapper.Map<List<BookResponse>>(books)),
                error => Problem(error));
        }

        //Get book details with the list of reviews
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsResponse>> GetBooksDetails(int id)
        {
            var query = new GetBookDetailsQuery(id);

            var result = await _mediator.Send(query);

            return result.Match(
                book => Ok(_mapper.Map<BookDetailsResponse>(book)),
                error => Problem(error));
        }
        #endregion

        #region POST

        [HttpPost("save")]
        public async Task<ActionResult<SaveBookResponse>> SaveBook(SaveBookRequest request)
        {
            var command = _mapper.Map<SaveBookCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                book => Ok(new SaveBookResponse(book.Id)),
                error => Problem(error));
        }

        #endregion

        #region PUT


        //Save a review for the book.
        [HttpPut("{id}/review")]
        public async Task<ActionResult<SaveReviewResponse>> SaveReview(int id,SaveReviewRequest request)
        {
            var command = _mapper.Map<SaveReviewCommand>((id,request));

            var result = await _mediator.Send(command);

            return result.Match(
                review => Ok(new SaveReviewResponse(review.Id)),
                error => Problem(error));
        }

        [HttpPut("{id}/rate")]
        public async Task<ActionResult> RateBook(int id, RateBookRequest request)
        {
            var command = _mapper.Map<RateBookCommand>((id,request));

            var result = await _mediator.Send(command);

            return result.Match(
                rating => Ok(new RateBookResponse(rating.Id)),
                error => Problem(error));
        }

        #endregion

        #region DELETE

        //Delete a book using a secret key. Save the secret key in the config of your application.
        //Compare this key with a query param

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteBookResponse>> DeleteBook(int id,[FromQuery]DeleteBookRequest request)
        {
            var secretKey = _configuration["Secret:SecretKey"];
            var command = _mapper.Map<DeleteBookCommand>((id,request,secretKey));

            var result = await _mediator.Send(command);

            return result.Match(
                book => Ok(new DeleteBookResponse(book.Id)),
                error => Problem(error));
        }

        #endregion

    }
}
