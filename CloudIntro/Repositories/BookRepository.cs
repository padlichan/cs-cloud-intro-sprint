namespace CloudIntro.Repositories
{
    public interface IBookRepository
    {
        public List<Book> FindBooks();
        public Book AddBook(BookDto book);
    }
    public class BookRepository : IBookRepository
    {
        private readonly BookShopContext _bookShopContext;
        public BookRepository(BookShopContext bookShopContext) 
        {
            _bookShopContext = bookShopContext;
        }
        public List<Book> FindBooks()
        {
            return _bookShopContext.Books.ToList();
        }

        public Book AddBook(BookDto bookDto)
        {
            Book book = new Book(bookDto.Title, bookDto.Author, bookDto.Description);
            _bookShopContext.Books.Add(book);
            _bookShopContext.SaveChanges();
            return _bookShopContext.Books.Last();
        }
    }
}
