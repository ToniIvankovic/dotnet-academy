using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ToniIvankovic.Services
{
    public class PeopleService : IPeopleService
    {
        private List<Person> _people;

        public PeopleService()
        {
            _people = new List<Person>
            {
                new Person(1, "Marko", "Markec", new Address("Ozaljska 23", "Zagreb", "Hrvatska")),
                new Person(2, "Anka", "Ankić", new Address("Petrova 23", "Osijek", "Hrvatska")),
                new Person(3, "Tanja", "Tanjić", new Address("Grossstrasse 23", "Wien", "Osterreich")),
                new Person(4, "Maja", "Majić", new Address("Savska 99", "Zagreb", "Hrvatska"))
            };

        }

        public Person CreatePerson(PersonDTO dto)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAllPersons()
        {
            return _people.ToList();
        }

        public List<Person> GetAllPersonsByCity(string City)
        {
            return _people.Where(p => p.Address.City.Equals(City)).ToList();
        }

        public Person GetPersonById(int id)
        {
            return _people.Where(p => p.Id.Equals(id)).FirstOrDefault(defaultValue: null);
        }
    }
}
