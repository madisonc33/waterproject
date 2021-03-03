using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WaterProject.Models;

namespace WaterProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //added set so that we can edit it
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<CharityDBContext>(options =>
            {
                //goes into option configuration file and sets the connectionstrings to match the appsetting string added, and uses SQL server
                options.UseSqlServer(Configuration["ConnectionStrings:WaterCharityConnection"]);
            });

            services.AddScoped<ICharityRepository, EFCharityRepository>();
        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    // Database connection string.
        //    // Make sure to update the Password value below from "Your_password123" to your actual password.
        //    var connection = @"Server=db;Database=master;User=sa;Password=Pleasework;";

        //    // This line uses 'UseSqlServer' in the 'options' parameter
        //    // with the connection string defined above.
        //    services.AddDbContext<CharityDBContext>(
        //        //options => options.UseSqlServer(connection));
        //        options => options.UseSqlServer(Configuration["ConnectionStrings:WaterCharityConnection"]));

        //    //services.AddIdentity<ApplicationUser, IdentityRole>()
        //    //    .AddEntityFrameworkStores<CharityDBContext>()
        //    //    .AddDefaultTokenProviders();

        //    //services.AddMvc();


        //}

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage",
                    "{category}/{page:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page",
                    "{page:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1 });

                endpoints.MapControllerRoute(
                    "pagination",
                    "Projects/{page}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
