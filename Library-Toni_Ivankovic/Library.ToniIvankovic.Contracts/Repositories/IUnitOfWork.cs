using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Entities;

namespace Library.ToniIvankovic.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        IPersonRepository People { get; }
        IRepository<Book> Books { get; }

        Task SaveChangesAsync();
    }
}
