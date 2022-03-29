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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IPersonRepository _people;
        private readonly IRepository<Book> _books;
        private readonly DbContext _dbContext;
        public UnitOfWork(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IPersonRepository People => _people ?? new PersonRepository(_dbContext);
        public IRepository<Book> Books => _books ?? new Repository<Book>(_dbContext);

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
