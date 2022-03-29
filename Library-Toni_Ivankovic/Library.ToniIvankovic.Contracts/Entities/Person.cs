using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Library.ToniIvankovic.Contracts.Entities
{
    public class Person : IdentityUser<int>
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<Book> RentedBooks { get; set; }

        public void RentBook(Book book)
        {
            const int maxBooksRented = 4;
            if (RentedBooks.Count > maxBooksRented)
            {
                throw new Exception("Maximum number of books already rented!");
            }
            if (RentedBooks.Contains(book))
            {
                throw new Exception("Cannot rent the same book twice at the same time");
            }
            else
            {
                RentedBooks.Add(book);
                book.Rent();
            }
        }

        public void ReturnBook(int bookId)
        {
            var book = RentedBooks.Find(b => b.Id == bookId);
            if (book == null)
            {
                throw new Exception($"The book with the id {bookId} has not even been borrowed!");
            }

            RentedBooks.Remove(book);
            book.Return();
        }
    }
}
