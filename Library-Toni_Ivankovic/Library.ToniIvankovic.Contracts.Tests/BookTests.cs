using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Exceptions;
using Xunit;

namespace Library.ToniIvankovic.Contracts.Tests
{
    public class BookTests
    {
        private Book book;
        private readonly Person _person;

        public BookTests()
        {
            book = new Book(1, "Bla", "Author1, Author2", Genre.FANTASY, 1);
            _person = new Person()
            {
                Id = 1,
                FirstName = "Toni",
                LastName = "Ivanković",
                Address = new Address()
                {
                    Street = "Odranska 5",
                    City = "Zagreb",
                    Country = "Hrvatska",
                },
            };
        }

        [Fact]
        public void ConstructBook_WhenParamsAreValid_ThenSuccesfully()
        {
            book = new Book(2, "Blab", "Author3, Author2", Genre.SCI_FI, 3);
            Assert.Equal(2, book.Id);
            Assert.Equal("Blab", book.Title);
            Assert.Equal("Author3, Author2", book.Authors);
            Assert.Equal(Genre.SCI_FI, book.Genre);
            Assert.Equal(3, book.Quantity);
        }

        [Fact]
        public void IsAvailable_WhenQuantityIsGreaterThan0_ThenReturnTrue()
        {
            Assert.True(book.IsAvailable());
        }

        [Fact]
        public void IsAvailable_WhenQuantityIs0_ThenReturnFalse()
        {
            book.Rent();
            Assert.False(book.IsAvailable());
        }

        [Fact]
        public void Rent_WhenAvailable_ThenDecreaseQuantity()
        {
            Assert.Equal(1, book.Quantity);
            book.Rent();
            Assert.Equal(0, book.Quantity);
        }

        [Fact]
        public void Rent_WhenNotAvailable_ThenThrowException()
        {
            book.Rent();
            Assert.Throws<BookNotAvailableException>(() => book.Rent());
        }

        [Fact]
        public void Return_ThenIncreaseQuantity()
        {
            Assert.Equal(1, book.Quantity);
            book.Return();
            Assert.Equal(2, book.Quantity);
        }

        [Fact]
        public void Rent_WhenNotRented_ThenAddPersonToRentedList()
        {
            _person.RentBook(book);
            Assert.Contains(_person, book.CurrentlyRentedBy);
        }

        [Fact]
        public void Return_WhenRented_ThenRemovePersonFromRentedList()
        {
            _person.RentBook(book);
            _person.ReturnBook(book.Id);
            Assert.DoesNotContain(_person, book.CurrentlyRentedBy);
        }

    }
}
