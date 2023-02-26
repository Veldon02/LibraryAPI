namespace Api.Contracts.SaveBook
{
    public record SaveBookRequest(
        int? Id,
        string Title,
        string Cover,
        string Content,
        string Genre,
        string Author);
}
