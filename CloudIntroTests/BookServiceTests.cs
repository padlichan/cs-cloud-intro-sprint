using CloudIntro;
using CloudIntro.Repositories;
using CloudIntro.Services;
using Moq;
using FluentAssertions;

namespace CloudIntroTests
{
    public class BookServiceTests
    {
        private Mock<IBookRepository> _bookRepository;
        private BookService _bookService;
        private Book book1 = new Book("Title1", "Author1", "Description1");
        private Book book2 = new Book("Title2", "Author2", "Description2");
        private Book book3 = new Book("Title3", "Author3", "Description3");

        [SetUp]
        public void Setup()
        {
            _bookRepository = new Mock<IBookRepository>();
            _bookService = new BookService(_bookRepository.Object);
        }

        [Test]
        public void FindBooks_ShouldReturnCorrectBooks()
        {
            IEnumerable<Book> expectedResult = [ book1, book2, book3 ];
            _bookRepository.Setup(r => r.FindBooks()).Returns([book1, book2, book3]);

            var result = _bookService.FindBooks();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void FindBooks_ShouldInvokeRepositoryMethodOnce()
        {
            _bookRepository.Setup(r => r.FindBooks()).Returns([book1, book2, book3]);

            _ = _bookService.FindBooks();

            _bookRepository.Verify(r => r.FindBooks(), Times.Once);
        }
    }
}