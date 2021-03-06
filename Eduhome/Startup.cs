using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Repository;
using Business.Services;
using DAL.Data;
using DAL.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Eduhome
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("Default"));
            });

            services.AddScoped<ISliderService, SliderRepository>();
            services.AddScoped<ICardService, CardRepository>();
            services.AddScoped<IBlogService, BlogRepository>();
            services.AddScoped<IEventService, EventRepository>();
            services.AddScoped<IImageService, ImageRepository>();
            services.AddScoped<ITestimonialService, TestimonialRepository>();
            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(2);
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
                //options.SignIn.RequireConfirmedEmail = true ;
            });



            services.AddScoped<SettingRepository>();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute
                (
                    name: "Admin",
                    pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}"
                 );

                endpoints.MapControllerRoute
                (
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                 );


            });
        }
    }
}

