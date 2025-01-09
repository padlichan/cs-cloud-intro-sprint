using CloudIntro;
using CloudIntro.Controllers;
using CloudIntro.Services;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CloudIntroTests
{
    public class BooksControllerTests
    {
        private Mock<IBookService> _bookService;
        private BooksController _bookController;
        private Book book1 = new Book("Title1", "Author1", "Description1");
        private Book book2 = new Book("Title2", "Author2", "Description2");
        private Book book3 = new Book("Title3", "Author3", "Description3");

        [SetUp]
        public void Setup()
        {
            _bookService = new Mock<IBookService>();
            _bookController = new BooksController(_bookService.Object);
        }

        [Test]
        public void Index_ShouldReturnOkObjectResult()
        {
            _bookService.Setup(s => s.FindBooks()).Returns([book1, book2, book3]);

            var result = _bookController.Index() as OkObjectResult;

            result.Should().NotBeNull();
        }

        [Test]
        public void Index_ShouldReturnCorrectResult()
        {
            List<Book> expectedResult = [book1, book2, book3];
            _bookService.Setup(s => s.FindBooks()).Returns([book1, book2, book3]);

            var result = ((OkObjectResult)_bookController.Index())?.Value as List<Book>;

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Index_ShouldInvokeServiceLayerOnce()
        {
            _bookService.Setup(s => s.FindBooks()).Returns([book1, book2, book3]);

            _ = _bookController.Index();

            _bookService.Verify(s => s.FindBooks(), Times.Once());
        }
    }
}
