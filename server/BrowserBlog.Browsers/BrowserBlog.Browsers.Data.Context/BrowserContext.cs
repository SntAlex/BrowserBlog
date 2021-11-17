using BrowserBlog.Browsers.Data.Context.Configurations;
using BrowserBlog.Browsers.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrowserBlog.Browsers.Data.Context
{
    public class BrowserContext : DbContext
    {
        public DbSet<Browser> Browsers { get; set; }
        public DbSet<BrowserPage> BrowserPages { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public BrowserContext(DbContextOptions<BrowserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BrowserConfiguration());
            modelBuilder.ApplyConfiguration(new BrowserPageConfiguration());
        }
    }
}