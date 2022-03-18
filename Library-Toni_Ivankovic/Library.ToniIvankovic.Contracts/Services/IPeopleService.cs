using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;

namespace Library.ToniIvankovic.Contracts.Services
{
    public interface IPeopleService
    {
        List<Person> GetAllPersons();
        Person GetPersonById(int id);
        Person CreatePerson(PersonDTO dto);
        List<Person> GetAllPersonsByCity(string City);
    }
}
