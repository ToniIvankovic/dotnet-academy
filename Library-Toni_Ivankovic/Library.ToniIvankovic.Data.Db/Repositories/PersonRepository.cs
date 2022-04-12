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

        public override async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _dbSet
                .Include(p => p.Address)
                .Include(p => p.RentedBooks)
                .ToListAsync();
        }

        public override async Task<Person?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Address)
                .Include(p => p.RentedBooks)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Person>> GetAllPersonsByCity(string city)
        {
            return await _dbSet
                .Where(p => p.Address.City == city)
                .Include(p => p.Address)
                .Include(p => p.RentedBooks)
                .ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetPeopleWithBookRentedBeforeDate(DateTime date)
        {
            return await _dbSet
                .Include(p => p.RentedBooks.Where(r => r.RentingDateTime < date))
                .ToListAsync();
        }
    }
}
