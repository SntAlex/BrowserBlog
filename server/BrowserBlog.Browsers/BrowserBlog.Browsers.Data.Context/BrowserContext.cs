﻿using BrowserBlog.Browsers.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrowserBlog.Browsers.Data.Context
{
    public class BrowserContext : DbContext
    {
        public DbSet<Browser> Browsers { get; set; }

        public BrowserContext(DbContextOptions<BrowserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}