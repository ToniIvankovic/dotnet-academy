using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Entities;

namespace Library.ToniIvankovic.Contracts.Repositories
{
    internal interface IUnitOfWork
    {
        IRepository<Person> People { get; }

        Task SaveChangesAsync();
    }
}
