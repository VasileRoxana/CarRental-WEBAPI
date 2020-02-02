using CarRental.Domain.EF;
using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.EF.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRental.WebAPI
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
            services.AddControllers();
            services.ConfigureDbContext(Configuration);
            services.InjectRepositories();
            services.InjectServices(); 
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<CarRentalDbContext>();
            services.AddSingleton<ICarRepository, MockCar>();
        }
 
        /// <param name="app"></param>
        /// <param name="env"></param>

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseMvc(routes =>
           {
               routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
           });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}
