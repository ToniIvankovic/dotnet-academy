using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Repositories;
using Library.ToniIvankovic.Contracts.Services;
using Library.ToniIvankovic.Data.Db.Repositories;

namespace Library.ToniIvankovic.Services
{
    public class BooksService : IBooksService
    {
        private readonly IUnitOfWork _uow;

        public BooksService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<BookCatalogDTO>> GetAllBooksAsync()
        {
            var books = await _uow.Books.GetAllAsync();
            return books.Select(book => book.ToCatalogDTO()).ToList();
        }

        public async Task<List<Book>> GetAllRentedBooks(int personId)
        {
            var person = await _uow.People.GetByIdAsync(personId);
            if (person == null)
            {
                throw new ArgumentException($"Unknown person with id {personId}!");
            }

            return person.RentedBooks;
        }

        public Task<Book?> GetBookByIdAsync(int id)
        {
            return _uow.Books.GetByIdAsync(id);
        }

        public async Task RentBookAsync(int personId, int bookId)
        {
            var book = await _uow.Books.GetByIdAsync(bookId);
            if (book == null)
            {
                throw new ArgumentException($"Unknown book with id {bookId}!");
            }

            var person = await _uow.People.GetByIdAsync(personId);
            if (person == null)
            {
                throw new ArgumentException($"Unknown person with id {personId}!");
            }

            person.RentBook(book);
            // _uow.Books.Update(book);     // ZAŠ NE TREBA UPDATE?
            await _uow.SaveChangesAsync();
        }

        public async Task ReturnBookAsync(int personId, int bookId)
        {

            var person = await _uow.People.GetByIdAsync(personId);
            if (person == null)
            {
                throw new ArgumentException($"Unknown person with id {personId}!");
            }

            person.ReturnBook(bookId);
            // _uow.Books.Update(book);
            await _uow.SaveChangesAsync();
        }
    }
}
