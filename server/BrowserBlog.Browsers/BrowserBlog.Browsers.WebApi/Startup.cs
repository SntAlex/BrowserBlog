using BrowserBlog.Browsers.Data.Context;
using BrowserBlog.Browsers.Data.Repositories;
using BrowserBlog.Browsers.Domain.Contracts.Repositories;
using BrowserBlog.Browsers.Domain.Contracts.Services;
using BrowserBlog.Browsers.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BrowserBlog.Browsers.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddAutoMapper(cfg =>
                cfg.AddMaps("BrowserBlog.Browsers.WebApi", "BrowserBlog.Browsers.Services")
            );
            services.AddDbContext<BrowserContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBrowserService, BrowserService>();
            services.AddScoped<IBrowserPageService, BrowserPageService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}