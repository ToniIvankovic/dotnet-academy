using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Exceptions;
using Library.ToniIvankovic.Contracts.Repositories;
using Library.ToniIvankovic.Data.Db.Configurations;
using Moq;
using Xunit;

namespace Library.ToniIvankovic.Services.Tests
{
    public class BookServiceTests
    {
        private readonly BooksService _sut;
        private readonly Mock<IUnitOfWork> _uowMock;
        private readonly IEnumerable<Book> bookMocks;
        public BookServiceTests()
        {
            _uowMock = new Mock<IUnitOfWork>();
            _sut = new BooksService(_uowMock.Object);
            bookMocks = BookMocks.Books;
        }

        [Fact]
        public async void GetBooks_WhenRepositoryReturnsData_ThenMapToDtoType()
        {
            _uowMock.Setup(x => x.Books.GetAllAsync())
                .Returns(Task.FromResult(bookMocks));
            Assert.IsType<List<BookCatalogDTO>>(await _sut.GetAllBooksAsync());
        }

        [Fact]
        public async void GetBooks_WhenRepositoryReturnsData_ThenReturnDtosCorrectSize()
        {
            _uowMock.Setup(x => x.Books.GetAllAsync())
                .Returns(Task.FromResult(bookMocks));

            var expectedCount = bookMocks.Count();
            Assert.Equal(expectedCount, (await _sut.GetAllBooksAsync()).Count);
        }

        [Fact]
        public async Task RentBook_WhenRepositoryCannotFindBook_ThenThrowException()
        {
            _uowMock.Setup(x => x.Books.GetAllAsync())
                .Returns(Task.FromResult(bookMocks.Where(b => b.Id > 1)));

            _uowMock.Setup(x => x.Books.GetByIdAsync(1))
                .Returns(Task.FromResult<Book?>(null));

            _uowMock.Setup(x => x.People.GetByIdAsync(1))
                .Returns(Task.FromResult<Person?>(new Person()));

            await Assert.ThrowsAsync<EntityNotFoundException>(() => _sut.RentBookAsync(1, 1));
        }

        [Fact]
        public async Task RentBook_WhenRepositoryCannotFindPerson_ThenThrowException()
        {
            _uowMock.Setup(x => x.Books.GetAllAsync())
                .Returns(Task.FromResult(bookMocks));

            _uowMock.Setup(x => x.Books.GetByIdAsync(1))
                .Returns(Task.FromResult<Book?>(bookMocks.First()));

            _uowMock.Setup(x => x.People.GetByIdAsync(1))
                .Returns(Task.FromResult<Person?>(null));

            await Assert.ThrowsAsync<EntityNotFoundException>(() => _sut.RentBookAsync(1, 1));
        }

        [Fact]
        public async Task RentBook_WhenRepositoryCanFindPersonAndBook_ThenAddToBothLists()
        {
            Book book = bookMocks.First();
            Person person = new Person()
            {
                Id = 1,
            };

            _uowMock.Setup(x => x.Books.GetAllAsync())
                .Returns(Task.FromResult(bookMocks.Where(b => b.Id == book.Id)));

            _uowMock.Setup(x => x.Books.GetByIdAsync(1))
                .Returns(Task.FromResult<Book?>(book));

            _uowMock.Setup(x => x.People.GetByIdAsync(1))
                .Returns(Task.FromResult<Person?>(person));

            await _sut.RentBookAsync(person.Id, book.Id);
            Assert.Contains(book, person.RentedBooks.Select(r => r.Book));
            Assert.Contains(person, book.CurrentlyRentedBy);
        }

        [Fact]
        public async Task GetRentedBooks_WhenRepositoryCannotFindPerson_ThenThrowExceptionAsync()
        {
            _uowMock.Setup(x => x.Books.GetAllAsync())
                .Returns(Task.FromResult(bookMocks));

            _uowMock.Setup(x => x.Books.GetByIdAsync(1))
                .Returns(Task.FromResult<Book?>(bookMocks.First()));

            _uowMock.Setup(x => x.People.GetByIdAsync(1))
                .Returns(Task.FromResult<Person?>(null));

            await Assert.ThrowsAsync<EntityNotFoundException>(() => _sut.GetAllRentedBooks(1));
        }

        [Fact]
        public async Task GetRentedBooks_WhenRepositoryCanFindPerson_ThenCheckListContainsAsync()
        {
            Book book = bookMocks.First();
            _uowMock.Setup(x => x.Books.GetAllAsync())
                .Returns(Task.FromResult(bookMocks));

            _uowMock.Setup(x => x.Books.GetByIdAsync(1))
                .Returns(Task.FromResult<Book?>(book));

            _uowMock.Setup(x => x.People.GetByIdAsync(1))
                .Returns(Task.FromResult<Person?>(new Person() { Id = 1 }));

            await _sut.RentBookAsync(1, book.Id);
            List<BookCatalogDTO> rentedBooks = await _sut.GetAllRentedBooks(1);
            Assert.Equal(book.ToCatalogDTO().Id, rentedBooks.Where(x => x.Id == book.Id).First().Id);
            //Assert.Contains(book.ToCatalogDTO(), rentedBooks);
        }

        [Fact]
        public async Task ReturnBook_WhenRepositoryCannotFindPerson_ThenThrowExceptionAsync()
        {
            _uowMock.Setup(x => x.Books.GetAllAsync())
                .Returns(Task.FromResult(bookMocks));

            _uowMock.Setup(x => x.Books.GetByIdAsync(1))
                .Returns(Task.FromResult<Book?>(bookMocks.First()));

            _uowMock.Setup(x => x.People.GetByIdAsync(1))
                .Returns(Task.FromResult<Person?>(null));

            await Assert.ThrowsAsync<EntityNotFoundException>(() => _sut.ReturnBookAsync(1, 1));
        }

        [Fact]
        public async Task ReturnBook_WhenRepositoryCannotFindBook_ThenThrowExceptionAsync()
        {
            _uowMock.Setup(x => x.Books.GetAllAsync())
                .Returns(Task.FromResult(bookMocks.Where(b => b.Id != 1)));

            _uowMock.Setup(x => x.Books.GetByIdAsync(1))
                .Returns(Task.FromResult<Book?>(null));

            _uowMock.Setup(x => x.People.GetByIdAsync(1))
                .Returns(Task.FromResult<Person?>(new Person() { Id = 1 }));

            await Assert.ThrowsAsync<BookRentingException>(() => _sut.ReturnBookAsync(1, 1));
        }

    }
}
