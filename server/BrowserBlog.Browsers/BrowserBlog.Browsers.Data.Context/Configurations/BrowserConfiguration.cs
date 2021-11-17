using BrowserBlog.Browsers.Data.Context.Configurations.Base;
using BrowserBlog.Browsers.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrowserBlog.Browsers.Data.Context.Configurations
{
    public class BrowserConfiguration : BaseEntityConfiguration<Browser>
    {
        public override void Configure(EntityTypeBuilder<Browser> builder)
        {
            base.Configure(builder);
            builder.HasIndex(entity => entity.Name).IsUnique();
            builder.Property(entity => entity.Name).IsRequired().HasMaxLength(60);
            builder.Property(entity => entity.Description).HasMaxLength(1000);
        }
    }
}