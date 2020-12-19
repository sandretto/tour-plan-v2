using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestTourPlan.Services;
using Microsoft.Extensions.Configuration;
using BestTourPlan.Domain.Repositories.Abstract;
using BestTourPlan.Domain.Repositories.Concrete;
using BestTourPlan.Domain;
using Microsoft.EntityFrameworkCore;
using Config = BestTourPlan.Services.Configuration;
using Microsoft.AspNetCore.Identity;

namespace BestTourPlan
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());

            services.AddTransient<IHotelRepository, EFHotelRepository>();

            services.AddDbContext<AppDbContext>(x => 
                x.UseSqlServer(Config.ConnectionString));

            services.AddIdentity<CustomIdentityUser, IdentityRole>(x => 
            {
                x.User.RequireUniqueEmail = true;
                x.Password.RequiredLength = 5;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(x => 
            {
                x.Cookie.Name = "TourPlanAuth";
                x.Cookie.HttpOnly = true;
                x.LoginPath = "/account/login";
                x.AccessDeniedPath = "/account/accessdenied";
                x.SlidingExpiration = true;
            });

            services.AddControllersWithViews()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                .AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Show}/{id?}");
            });
        }
    }
}
