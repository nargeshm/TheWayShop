using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PresentataionHost.Models;
using PresentataionHost.PaymentSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS.Core.ApplicationService;
using WS.Core.Contracts.Pay;
using WS.Core.Contracts.Repository;
using WS.Core.Contracts.Service;
using WS.Core.Entites;
using WS.Infrastruture.Data;
using WS.Infrastruture.Sql;

namespace PresentataionHost
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
            services.AddDbContext<DemoContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("TheWayShop"));
            });
            /* identity:*/
            services.AddDbContext<IdentityContext>(option => option.UseSqlServer(Configuration.GetConnectionString("IdentityCS")));
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

            /* identity:*/
            services.AddTransient<IPayment, PayIr>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProdctService, ProductService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<Cart>(sp => SessionCart.GetCart(sp));

            services.AddScoped<IOrderRepository, OrederRepository>();
            services.AddScoped<IOrderService, OrderService>();
          
            services.AddSession();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
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
            app.UseStaticFiles();
           
            app.UseRouting();
            app.UseSession();
            app.UseCookiePolicy();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
