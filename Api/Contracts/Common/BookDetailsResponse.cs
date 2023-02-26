using Domain.Entities;

namespace Api.Contracts.Common
{
    public record BookDetailsResponse(
        int Id,
        string Title,
        string Cover,
        string Content,
        string Author,
        string Genre,
        decimal AverageRating,
        List<ReviewResponse> Reviews);

    

    public record ReviewResponse(
        int Id,
        string Message,
        string Reviewer);
}
