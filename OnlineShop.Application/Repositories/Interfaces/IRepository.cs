using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Repositories.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public Task<TKey> AddAsync(TEntity entity);
        public Task<IEnumerable<TKey>> AddRangeAsync(IEnumerable<TEntity> entities);

        public Task<TEntity> GetByIdAsync(TKey id);
        public Task<IEnumerable<TEntity>> GetAllAsync();

        public Task Update(TEntity entity);

        public Task Remove(TEntity entity);
        public Task RemoveById(TKey id);

        public IQueryable<TEntity> GetQuery();
    }
}
