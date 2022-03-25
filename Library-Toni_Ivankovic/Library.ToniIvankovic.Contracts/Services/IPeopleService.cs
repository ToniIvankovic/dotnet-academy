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
        Task<List<Person>> GetAllPersonsAsync();

        Task<Person>? GetPersonByIdAsync(int id);

        Person CreatePerson(PersonDTO dto);

        List<Person> GetAllPersonsByCity(string city);
    }
}
