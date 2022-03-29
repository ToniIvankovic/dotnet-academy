using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Entities;

namespace Library.ToniIvankovic.Data.Db.Configurations
{
    public static class BookMocks
    {
        public static IEnumerable<Book> Books => new List<Book>
        {
            new Book(1, "The Song of Achilles", "Madeline Miller", Genre.MYTHOLOGY, 5),
            new Book(2, "The Hunger Games", "Suzane Collins", Genre.DYSTOPIA, 3),
            new Book(3, "Napredno programiranje i algoritmi u C-u i C++-u", "Domagoj Kusalić", Genre.NON_FICTION, 1),
            new Book(4, "Fahrenheti 451", "Ray Bradburry", Genre.DYSTOPIA, 5),
            new Book(5, "Call Me By Your Name", "Andre Aciman", Genre.ROMANCE_NOVEL, 7),

        };
    }
}
