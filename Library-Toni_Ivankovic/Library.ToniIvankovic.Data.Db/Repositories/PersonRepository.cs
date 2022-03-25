using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Entities;
using Library.ToniIvankovic.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.ToniIvankovic.Data.Db.Repositories
{
    internal class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Person>> GetAllPersonsByCity(string city)
        {
            return await _dbSet.Where(p => p.Address.City == city).ToListAsync();
        }
    }
}
