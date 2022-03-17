using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ToniIvankovic.Contracts.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

        public Person(int id, string firstName, string lastName, Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
    }
}
