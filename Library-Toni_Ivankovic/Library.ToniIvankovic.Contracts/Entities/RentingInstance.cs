using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ToniIvankovic.Contracts.Entities
{
    public class RentingInstance
    {
        public Person Person { get; }
        public DateTime RentingDateTime { get; }
        public Book Book { get; }

        public RentingInstance()
        {
            RentingDateTime = DateTime.UtcNow;
        }

        public RentingInstance(Person p, Book b) : this()
        {
            Person = p;
            Book = b;
        }

    }
}
