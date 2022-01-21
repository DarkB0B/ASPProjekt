using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AspProj10.Models;
using Microsoft.AspNetCore.Identity;

namespace AspProj10
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration["Data:Posts:ConnectionString"]));
            // services.AddTransient<IPostRepository, EFPostRepository>();
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(Configuration["Data:Posts:ConnectionString"]));
            services.AddTransient<ICrudPostRepository, EFCrudPostRepository>();
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(Configuration["Data:Posts:ConnectionString"]));
            services.AddTransient<ICrudCategoryRepository, EFCrudCategoryRepository>();
            services.AddTransient<ICrudCommentRepository, EFCrudCommentRepository>();
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(Configuration["Data:Posts:ConnectionString"]));
            services.AddTransient<ICrudCommentRepository, EFCrudCommentRepository>();
            services.AddDbContext<AppIdentityDbContext>(options =>
             options.UseSqlServer(Configuration["Data:AppIdentity:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();

            services.AddSingleton<BasicAuthorizationFilter>();
            


            services.AddControllersWithViews();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

            services.AddMvc().AddMvcOptions(options =>
            {
                options.Filters.AddService<BasicAuthorizationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
