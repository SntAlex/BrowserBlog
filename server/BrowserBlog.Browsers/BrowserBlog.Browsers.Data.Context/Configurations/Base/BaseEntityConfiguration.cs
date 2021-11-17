using BrowserBlog.Browsers.Domain.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrowserBlog.Browsers.Data.Context.Configurations.Base
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity: BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(entity => entity.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(entity => entity.UpdatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}