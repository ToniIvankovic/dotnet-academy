using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Exceptions;

namespace Library.ToniIvankovic.Contracts.Entities
{
    public class Book
    {
        public int Id { get; }
        public string Title { get; }
        public string Authors { get; }
        public Genre Genre { get; }
        public int Quantity { get; private set; }
        public List<Person> CurrentlyRentedBy { get; }

        public Book(int id, string title, string authors, Genre genre, int quantity)
        {
            Id = id;
            Title = title;
            Authors = authors;
            Genre = genre;
            Quantity = quantity;
            CurrentlyRentedBy = new List<Person>();
        }

        public bool IsAvailable() => Quantity > 0;
        public void Rent()
        {
            if (!IsAvailable())
            {
                throw new BookNotAvailableException("No more of this book left in storage!");
            }
            else
            {
                Quantity--;
            }
        }
        public void Return()
        {
            Quantity++;
        }

        public BookCatalogDTO ToCatalogDTO()
        {
            return new BookCatalogDTO
            {
                Authors = Authors,
                Genre = Genre,
                Quantity = Quantity,
                Title = Title,
                Id = Id,
            };
        }
    }
}
