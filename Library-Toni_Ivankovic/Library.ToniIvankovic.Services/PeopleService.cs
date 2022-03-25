using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Repositories;
using Library.ToniIvankovic.Contracts.Services;

namespace Library.ToniIvankovic.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IUnitOfWork unitOfWork;
        public PeopleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Person CreatePerson(PersonDTO dto)
        {
            Person p = new Person(dto.FirstName, dto.LastName, new Address(dto.Street, dto.City, dto.Country));
            unitOfWork.People.Add(p);
            return p;
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            return (await unitOfWork.People.GetAllAsync()).ToList();
        }

        public List<Person> GetAllPersonsByCity(string City)
        {
            return unitOfWork.People.GetAllPersonsByCity(City);
        }

        public async Task<Person?> GetPersonByIdAsync(int id)
        {
            return await unitOfWork.People.GetByIdAsync(id);
        }
    }
}
