using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BrowserBlog.Browsers.Data.Context;
using BrowserBlog.Browsers.Domain.Contracts.Repositories.Base;
using BrowserBlog.Browsers.Domain.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace BrowserBlog.Browsers.Data.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: BaseEntity
    {
        protected readonly BrowserContext _dbContext;
        protected readonly DbSet<TEntity> _entities;

        public Repository(BrowserContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(bool tracking = false)
        {
            return tracking ? _entities.AsTracking() : _entities.AsNoTracking();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression, bool tracking = false)
        {
            var entities = Get(tracking);
            
            if (expression != null)
            {
                entities = entities.Where(expression);
            }

            return entities;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public async Task<TEntity> FindAsync(Guid id, bool tracking = false, params Expression<Func<TEntity, object>>[] inclusions)
        {
            var queryResult = tracking ? _entities.AsTracking() : _entities.AsNoTracking();

            queryResult = inclusions.Aggregate(queryResult, (current, inclusion) => current.Include(inclusion));

            return await queryResult.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }
    }
}