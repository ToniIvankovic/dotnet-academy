using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Services;

namespace Library.ToniIvankovic.Services
{
    public class PeopleService : IPeopleService
    {
        private static List<Person> people;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleService"/> class and initializes the people list, if it is not yet initialized.
        /// </summary>
        public PeopleService()
        {
            if (people != null)
            {
                return;
            }

            people = new List<Person>
            {
                //new Person(1, "Marko", "Markec", new Address(1, 1, "Ozaljska 23", "Zagreb", "Hrvatska")),
                //new Person(2, "Anka", "Ankić", new Address(2, 2, "Petrova 23", "Osijek", "Hrvatska")),
                //new Person(3, "Tanja", "Tanjić", new Address(3, 3, "Grossstrasse 23", "Wien", "Osterreich")),
                //new Person(4, "Maja", "Majić", new Address(4, 4, "Savska 99", "Zagreb", "Hrvatska")),
            };

        }

        public Person CreatePerson(PersonDTO dto)
        {
            int newId = people.Count + 1;
            Person newPerson = new (newId, dto.FirstName, dto.LastName);
            people.Add(newPerson);
            return newPerson;
        }

        public List<Person> GetAllPersons()
        {
            return people.ToList();
        }

        public List<Person> GetAllPersonsByCity(string City)
        {
            return people.Where(p => p.Address.City.Equals(City)).ToList();
        }

        public Person? GetPersonById(int id)
        {
            return people.Where(p => p.Id.Equals(id))
                .FirstOrDefault(defaultValue: null);
        }
    }
}
