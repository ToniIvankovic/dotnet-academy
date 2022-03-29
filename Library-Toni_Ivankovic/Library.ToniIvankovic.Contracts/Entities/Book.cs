using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Dtos;

namespace Library.ToniIvankovic.Contracts.Entities
{
    public class Book
    {
        public string Id { get; }
        public string Title { get; }
        public string Authors { get; }
        public Genre Genre { get; }
        public int Quantity { get; private set; }

        public Book(string title, string authors, Genre genre, int quantity)
        {
            Title = title;
            Authors = authors;
            Genre = genre;
            Quantity = quantity;
        }

        public bool IsAvailable() => Quantity > 0;
        public void Rent()
        {
            if (!IsAvailable())
            {
                throw new ArgumentException("No more of this book left in storage!");
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
