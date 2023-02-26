namespace Api.Contracts.Common
{
    public record BookResponse(
        int Id,
        string Title,
        string Genre,
        string Author,
        decimal Rating,
        int ReviewNumber);
}
