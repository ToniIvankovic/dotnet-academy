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

        Task<Person> CreatePerson(PersonDTO dto);

        Task<List<Person>> GetAllPersonsByCity(string city);
    }
}
