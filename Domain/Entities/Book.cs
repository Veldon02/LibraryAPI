namespace Domain.Entities.BookEntity
{
    public sealed class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Cover { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Genre{ get; set; } = null!;
        public List<Rating> Ratings { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
        public int ReviewNumber => Reviews.Count;
        public decimal AverageRating => Ratings.Count == 0 ? 0 : (decimal)Ratings.Average(x => x.Score);
    }
}
