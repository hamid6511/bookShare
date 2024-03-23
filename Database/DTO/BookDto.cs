namespace bookShare.Database.DTO
{
    public class BookDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int YearPublished { get; set; }

        public string Cover { get; set; } = string.Empty;

        public Guid UserId { get; set; }
    }
}
