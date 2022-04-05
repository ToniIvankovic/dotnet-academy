using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Exceptions;
using Library.ToniIvankovic.Data.Db.Configurations;
using Xunit;

namespace Library.ToniIvankovic.Contracts.Tests
{
    public class PersonTests
    {
        private readonly Book _book;
        private Person person;

        public PersonTests()
        {
            person = new Person();
            _book = new Book(1, "Bla", "Author1, Author2", Genre.FANTASY, 1);
        }

        [Fact]
        public void RentBook_WhenBookNotAvailable_ThenThrowException()
        {
            new Person().RentBook(_book);
            Assert.Throws<BookNotAvailableException>(() => person.RentBook(_book));
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
            books.Where(b => b.Id <= 4).ToList().ForEach(book => person.RentBook(book));
            Assert.Throws<BookRentingException>(() => person.RentBook(books.Where(b => b.Id == 5).FirstOrDefault(_book)));
        }

        [Fact]
        public void RentBook_WhenAlreadyRented_ThenThrowException()
        {
            person.RentBook(_book);
            Assert.Throws<BookRentingException>(() => person.RentBook(_book));
        }

        [Fact]
        public void ReturnBook_WhenNotRented_ThenThrowException()
        {
            Assert.Throws<BookRentingException>(() => person.ReturnBook(_book.Id));
        }

        [Fact]
        public void ReturnBook_WhenRented_ThenIncreaseQuantity()
        {
            person.RentBook(_book);
            person.ReturnBook(_book.Id);
            Assert.Equal(1, _book.Quantity);
        }

        [Fact]
        public void RentBook_WhenNotRented_ThenPutIntoList()
        {
            person.RentBook(_book);
            Assert.Contains(_book, person.RentedBooks);
        }

        [Fact]
        public void ReturnBook_WhenRented_ThenRemoveFromList()
        {
            person.RentBook(_book);
            person.ReturnBook(_book.Id);
            Assert.DoesNotContain(_book, person.RentedBooks);
        }

        [Fact]
        public void RentBook_WhenNotRented_ThenAddBookToRentedList()
        {
            person.RentBook(_book);
            Assert.Contains(_book, person.RentedBooks);
        }

        [Fact]
        public void Return_WhenRented_ThenRemovePersonFromRentedList()
        {
            person.RentBook(_book);
            person.ReturnBook(_book.Id);
            Assert.DoesNotContain(_book, person.RentedBooks);
        }
    }
}
