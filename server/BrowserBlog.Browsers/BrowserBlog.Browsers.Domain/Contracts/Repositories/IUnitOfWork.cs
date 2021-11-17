using BrowserBlog.Browsers.Domain.Contracts.Repositories.Base;
using BrowserBlog.Browsers.Domain.Models.Entities.Base;
using System.Threading.Tasks;

namespace BrowserBlog.Browsers.Domain.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        Task CommitAsync();
    }
}