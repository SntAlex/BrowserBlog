using BrowserBlog.Browsers.Domain.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BrowserBlog.Browsers.Domain.Contracts.Repositories.Base
{
    public interface IRepository { }

    public interface IRepository<TEntity> : IRepository where TEntity : BaseEntity
    {
        IQueryable<TEntity> Get(bool tracking = false);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression, bool tracking = false);
        Task AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entities);
        Task<TEntity> FindAsync(Guid id);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
    }
}