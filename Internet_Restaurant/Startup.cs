using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internet_Restaurant.Data;
using Internet_Restaurant.Data.Interfaces;
using Internet_Restaurant.Data.Models;
using Internet_Restaurant.Data.Repository;
using Internet_Restaurant.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Internet_Restaurant
{
    public class Startup
    {
        //private IConfigurationRoot _confString;

        //[Obsolete]
        //public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
        //{
        //    _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        //}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
  
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
            // services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddTransient<IAllDishes, DishRepository>();
            services.AddTransient<IDishCategory, DishCategoryRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthentication();
            services.AddAuthorization();
            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc();
            services.AddMvcCore();
            services.AddRazorPages();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

                endpoints.MapControllerRoute
                (
                   name: "default",
                   pattern: "{controller=Main}/{action=Index}/{id?}"
                   );

                endpoints.MapControllerRoute
                (
                    name:"admin",
                    pattern:"{controller=Admin}/{action=Index}"
                    );
                endpoints.MapControllerRoute
               (
                   name: "salads",
                   pattern: "{controller=Main}/{action=Index}"
                   );
                endpoints.MapControllerRoute
              (
                  name: "pizzas",
                  pattern: "{controller=Main}/{action=Index}"
                  );
                endpoints.MapControllerRoute
              (
                  name: "list",
                  pattern: "{controller=Dish}/{action=List}"
                  );
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                AppDbInitializer.Initial(context);
            }

        }
    }
}
