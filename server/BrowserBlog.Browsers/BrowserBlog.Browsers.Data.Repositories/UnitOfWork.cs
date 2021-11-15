using System.Collections.Generic;
using BrowserBlog.Browsers.Data.Context;
using BrowserBlog.Browsers.Domain.Contracts.Repositories;
using BrowserBlog.Browsers.Domain.Contracts.Repositories.Base;
using BrowserBlog.Browsers.Domain.Models.Entities.Base;
using System.Threading.Tasks;
using BrowserBlog.Browsers.Data.Repositories.Base;

namespace BrowserBlog.Browsers.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BrowserContext _dbContext;
        private readonly IDictionary<string, IRepository> _repositories;

        public UnitOfWork(BrowserContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new SortedList<string, IRepository>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            var typeName = typeof(TEntity).FullName;

            if (!_repositories.ContainsKey(typeName))
            {
                _repositories.Add(typeName, new Repository<TEntity>(_dbContext));
            }

            return (IRepository<TEntity>) _repositories[typeName];
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}