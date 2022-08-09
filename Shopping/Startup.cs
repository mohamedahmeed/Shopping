using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopping.DTO;
using Shopping.Models;
using Shopping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping
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
            
            services.AddAutoMapper(typeof(UserProfile));   
            services.AddDbContext<Shipping>(option => option.UseSqlServer(Configuration.GetConnectionString("con")));
            services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 3;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireLowercase=false;
                option.Password.RequireUppercase=false;
            }).AddEntityFrameworkStores<Shipping>();
            services.AddScoped<IReposaitory<GovernmentDTO>, GovernmentServices>();
            services.AddScoped<IReposaitoryCity<CityDTO>, CityServices>();
            services.AddScoped<IReposaitory<PowerDTO>, PowerServices>();
            services.AddScoped<IReposaitory<OrderDTO>, OrderServices>();
            services.AddScoped<IReposaitory<ShippingPriceDTO>, ShippingPriceServices>();
            services.AddScoped<IReposaitory<ShippingTypesDTO>, ShippingTypesServices>();
            services.AddScoped<IReposaitory<ProductDTO>, ProductServices>();


            services.AddScoped<PowerServices>();
            services.AddScoped<ProductServices>();

            services.AddScoped<OrderServices>();








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
            }
            //app.Use((context, next) =>
            //{
            //    context.Request.EnableBuffering();
            //    return next();
            //});

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
         
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
