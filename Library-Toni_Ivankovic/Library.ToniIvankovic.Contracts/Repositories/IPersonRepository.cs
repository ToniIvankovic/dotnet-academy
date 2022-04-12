using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Entities;

namespace Library.ToniIvankovic.Contracts.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<List<Person>> GetAllPersonsByCity(string city);
        Task<IEnumerable<Person>> GetPeopleWithBookRentedBeforeDate(DateTime date);
    }
}
