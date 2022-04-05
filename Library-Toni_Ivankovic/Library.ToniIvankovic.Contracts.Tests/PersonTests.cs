using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Exceptions;
using Library.ToniIvankovic.Data.Db.Configurations;
using Xunit;

namespace Library.ToniIvankovic.Contracts.Tests
{
    public class PersonTests
    {
        private Person _sut;
        private readonly Book _book;

        public PersonTests()
        {
            _sut = new Person();
            _book = new Book(1, "Bla", "Author1, Author2", Genre.FANTASY, 1);
        }

        [Fact]
        public void RentBook_WhenBookNotAvailable_ThenThrowException()
        {
            new Person().RentBook(_book);
            Assert.Throws<BookNotAvailableException>(() => _sut.RentBook(_book));
        }

        [Fact]
        public void RentBook_WhenBookAvailable_DecreaseQuantity()
        {
            Assert.Equal(1, _book.Quantity);
            new Person().RentBook(_book);
            Assert.Equal(0, _book.Quantity);
        }

        [Fact]
        public void RentBook_WhenTooManyRented_ThenThrowException()
        {
            IEnumerable<Book> books = BookMocks.Books;
            books.Where(b => b.Id <= 4).ToList().ForEach(book => _sut.RentBook(book));
            Assert.Throws<BookRentingException>(() => _sut.RentBook(books.Where(b => b.Id == 5).FirstOrDefault(_book)));
        }

        [Fact]
        public void RentBook_WhenAlreadyRented_ThenThrowException()
        {
            _sut.RentBook(_book);
            Assert.Throws<BookRentingException>(() => _sut.RentBook(_book));
        }

        [Fact]
        public void ReturnBook_WhenNotRented_ThenThrowException()
        {
            Assert.Throws<BookRentingException>(() => _sut.ReturnBook(_book.Id));
        }

        [Fact]
        public void ReturnBook_WhenRented_ThenIncreaseQuantity()
        {
            _sut.RentBook(_book);
            _sut.ReturnBook(_book.Id);
            Assert.Equal(1, _book.Quantity);
        }

        [Fact]
        public void RentBook_WhenNotRented_ThenPutIntoList()
        {
            _sut.RentBook(_book);
            Assert.Contains(_book, _sut.RentedBooks);
        }

        [Fact]
        public void ReturnBook_WhenRented_ThenRemoveFromList()
        {
            _sut.RentBook(_book);
            _sut.ReturnBook(_book.Id);
            Assert.DoesNotContain(_book, _sut.RentedBooks);
        }
    }
}
