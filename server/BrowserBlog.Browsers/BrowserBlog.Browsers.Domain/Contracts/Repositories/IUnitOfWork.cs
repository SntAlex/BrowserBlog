using System.Threading.Tasks;
using BrowserBlog.Browsers.Domain.Contracts.Repositories.Base;
using BrowserBlog.Browsers.Domain.Models.Entities.Base;

namespace BrowserBlog.Browsers.Domain.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        Task CommitAsync();
    }
}