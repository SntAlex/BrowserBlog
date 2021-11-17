using BrowserBlog.Browsers.Data.Context.Configurations.Base;
using BrowserBlog.Browsers.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrowserBlog.Browsers.Data.Context.Configurations
{
    public class BrowserPageConfiguration : BaseEntityConfiguration<BrowserPage>
    {
        public override void Configure(EntityTypeBuilder<BrowserPage> builder)
        {
            base.Configure(builder);
        }
    }
}