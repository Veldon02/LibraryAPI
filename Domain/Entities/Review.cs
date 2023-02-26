namespace Domain.Entities
{
    public sealed class Review
    {
        public int Id { get; set; }
        public string Reviewer { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
