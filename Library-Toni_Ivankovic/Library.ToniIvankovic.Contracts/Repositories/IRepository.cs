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

        Task DeleteAsync(int id);

        void Add(TEntity entity);

        void Update(TEntity entity);
    }
}
