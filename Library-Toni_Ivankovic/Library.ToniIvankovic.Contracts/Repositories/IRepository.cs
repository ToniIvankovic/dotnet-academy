using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ToniIvankovic.Contracts.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        void DeleteAsync(int id);

        void AddAsync(TEntity entity);

        void Update(TEntity entity);
    }
}
