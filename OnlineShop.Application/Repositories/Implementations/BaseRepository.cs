using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Repositories.Implementations
{
    public class BaseRepository<TEntity, TKey> : 
        IRepository<TEntity, TKey> 
        where TEntity : BaseEntity<TKey>
    {
        private readonly IOnlineShopDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(IOnlineShopDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TKey> AddAsync(TEntity entity)
        {
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            var item = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return item.Entity.Id;
        }
        public async Task<List<TKey>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            List<TKey> result = new List<TKey>();

            foreach (TEntity entity in entities)
            {
                entity.CreateDate = DateTime.UtcNow;
                entity.UpdateDate = DateTime.UtcNow;
                TKey key = (await _dbSet.AddAsync(entity)).Entity.Id;
                result.Add(key);
            }

            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            TEntity entity = await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));

            return entity == null
                ? throw new ArgumentNullException(nameof(id), $"Entity not found by id ({id})")
                : entity;
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveByIdAsync(TKey id)
        {
            TEntity entity = await GetByIdAsync(id);

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            entity.UpdateDate = DateTime.UtcNow;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _dbSet.AsQueryable();
        }
    }
}
