using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Exceptions;
using Library.ToniIvankovic.Contracts.Repositories;
using Moq;
using Xunit;

namespace Library.ToniIvankovic.Contracts.Tests
{
    public class PersonTests
    {
        private Mock<IUnitOfWork> _uowMock;
        private Person _sut;

        public PersonTests()
        {
            _uowMock = new Mock<IUnitOfWork>();
            _sut = new Person();
        }

        [Fact]
        public void RentBook_WhenBookNotAvailable_ThenThrowException()
        {
            Book b = new Book(1, "Bla", "Author1, Author2", Genre.FANTASY, 1);
            //_uowMock.Setup(x => x.Books.GetByIdAsync(1))
            //    .Returns(Task.FromResult(b));
            new Person().RentBook(b);
            Assert.Throws<BookNotAvailableException>(() => _sut.RentBook(b));
        }

        [Fact]
        public void RentBook_WhenBookAvailable_DecreaseQuantity()
        {
            Book b = new Book(1, "Bla", "Author1, Author2", Genre.FANTASY, 2);
            Assert.Equal(2, b.Quantity);
            new Person().RentBook(b);
            Assert.Equal(1, b.Quantity);
        }

    }
}
