using FagElGamous.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*This program was created for a BYU excavation project by Rachel Vance, Kennedy Daniel, Ezra Frost, and Julie Handley. 
 * It is connected to a SQLServer DB. You will see each of the models and associated CRUD functionality, user accounts, and data display.*/
namespace FagElGamous
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public bool Production { get; set; } = true;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            //adding the database for the login and admin features
            services.AddDbContext<IdentityContext>(options => 
            { 
                if (Production)
                {
                options.UseSqlServer(Configuration["ConnectionStrings:IdentityConnection"]);
                }
                else
                {
                    options.UseSqlite(Configuration["ConnectionStrings:LocalConnection"]);
                }

            });
            if (Production)
            {
                services.AddDbContext<fagelgamousContext>(options =>
                {
                    options.UseSqlServer(Configuration["ConnectionStrings:FagelgamousConnection"]);
                });
            }
            services.AddScoped<IGamousRepository, EFGamousRepository>();


            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();


            //these are settings for password requirements, change as needed according the security requirements
            services.Configure<IdentityOptions>(options => {
                options.Password.RequiredLength = 10;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = true;
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

            //these required in this order for login services
            app.UseAuthentication();
            app.UseAuthorization();


            //endpoints for urls
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("pagenum",
                    "ViewRecords/{pageNum}",
                    new { Controller = "Home", action = "DataDisplay" });

                endpoints.MapControllerRoute("dataPage",
                    "{controller}/{action}/{pageNum}",
                    new { Controller = "Home", action = "DataDisplay" });

                endpoints.MapControllerRoute("dataAll",
                    "{controller}/{action}/{BurialId}",
                    new { Controller = "Home", action = "DataDisplay" });

                endpoints.MapControllerRoute("filter",
                    "{controller}/{action}/{burialid}",
                    new { Controller = "Home", action = "DataDisplay", method = "get"});

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

            //seeddata to create the groups and a sinlge admin user for the app
            IdentitySeedData.CreateAdminAccount(app.ApplicationServices, Configuration);
        }
    }
}
