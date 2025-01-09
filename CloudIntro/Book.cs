namespace CloudIntro
{
    public class Book
    {
        private static int nextBookId = 1;

        public Book(string title, string author, string description = "")
        {
            Id = nextBookId;
            nextBookId++;
            Title = title;
            Author = author;
            Description = description;
        }
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
