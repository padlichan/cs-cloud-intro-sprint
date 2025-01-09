using CloudIntro.Repositories;

namespace CloudIntro.Services
{
    public interface IBookService
    {
        public List<Book> FindBooks();
    }
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<Book> FindBooks()
        {
            return _bookRepository.FindBooks();
        }
        public Book AddBook(BookDto bookDto)
        {
            Book book = _bookRepository.AddBook(bookDto);
            return book;
        }
    }
}
