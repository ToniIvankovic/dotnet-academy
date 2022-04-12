using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Library.ToniIvankovic.Contracts.Entities
{
    public class Person : IdentityUser<int>
    {
        public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<RentingInstance> RentedBooks { get; set; }

        public Person()
        {
            RentedBooks = new List<RentingInstance>();
        }

        public void RentBook(Book book)
        {
            const int maxBooksRented = 4;
            if (RentedBooks.Count + 1 > maxBooksRented)
            {
                throw new BookRentingException("Maximum number of books already rented!");
            }

            if (RentedBooks.Select(r => r.Book).Contains(book))
            {
                throw new BookRentingException("Cannot rent the same book twice at the same time");
            }
            else
            {
                var renting = new RentingInstance(this, book);
                RentedBooks.Add(renting);
                book.Rent();
                book.CurrentlyRentedBy.Add(renting);
            }
        }

        public void ReturnBook(int bookId)
        {
            var book = RentedBooks.Select(r => r.Book).ToList().Find(b => b.Id == bookId);
            if (book == null)
            {
                throw new BookRentingException($"The book with the id {bookId} has not even been borrowed!");
            }

            RentingInstance? renting = RentedBooks.Find(r => r.Book == book);
            RentedBooks.Remove(renting);
            book.Return();
            book.CurrentlyRentedBy.Remove(renting);
        }
    }
}
