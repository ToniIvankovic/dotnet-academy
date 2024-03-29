using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.ToniIvankovic.Data.Db.Repositories
{
    public class Repository<TEntity>
        : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public async void AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async void DeleteAsync(int id)
        {
            TEntity? entity = await this.GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // TODO potencijalan problem
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
