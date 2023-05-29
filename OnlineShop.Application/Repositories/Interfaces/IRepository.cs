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
        public Task<List<TKey>> AddRangeAsync(IEnumerable<TEntity> entities);

        public Task<TEntity> GetByIdAsync(TKey id);
        public Task<List<TEntity>> GetAllAsync();

        public Task UpdateAsync(TEntity entity);

        public Task RemoveAsync(TEntity entity);
        public Task RemoveByIdAsync(TKey id);

        public IQueryable<TEntity> GetQuery();
    }
}
