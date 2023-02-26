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
using Application.Books.Queries.GetBooksOrderBy;
using Application.Books.Queries.GetTopBooks;
using Domain.Entities;
using Domain.Entities.BookEntity;
using Mapster;
using System.Configuration;

namespace Api.Mapping
{
    public class BooksConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<SaveBookRequest, SaveBookCommand>()
                .Map(dest => dest, src => src);

            config.NewConfig<(int id, DeleteBookRequest request, string key), DeleteBookCommand>()
                .Map(dest => dest.Id, src => src.id)
                .Map(dest => dest.ProvidedKey, src => src.request.SecretKey)
                .Map(dest => dest.SecretKey, src => src.key);

            config.NewConfig<(int id, SaveReviewRequest request), SaveReviewCommand>()
                .Map(dest => dest.BookId, src => src.id)
                .Map(dest => dest, src => src.request);

            config.NewConfig<(int id, RateBookRequest request), RateBookCommand>()
                .Map(dest => dest.BookId, src => src.id)
                .Map(dest => dest, src => src.request);

            config.NewConfig<Book, BookDetailsResponse>()
                .Map(dest => dest.Reviews, src => src.Reviews)
                .Map(dest => dest.AverageRating, src => src.AverageRating)
                .Map(dest => dest, src => src);
            

            config.NewConfig<Review, ReviewResponse>()
                .Map(dest => dest, src => src);

            config.NewConfig<Book, BookResponse>()
                .Map(dest => dest.Rating, src => src.AverageRating)
                .Map(dest => dest.ReviewNumber, src => src.ReviewNumber)
                .Map(dest => dest, src => src);

            config.NewConfig<(int count, GetTopBooksRequest request), GetTopBooksQuery>()
                .Map(dest => dest.Count, src => src.count)
                .Map(dest => dest, src => src.request);

        }
    }
}
