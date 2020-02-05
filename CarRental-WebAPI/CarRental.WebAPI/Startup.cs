using CarRental.Domain.EF;
using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.EF.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRental.WebAPI
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // every time an instance of CarRentalDb class is requested, instead of creating a new 
            // instance ASP checks if there is an instance available in the Pool
            services.AddDbContextPool<CarRentalDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("CarRentalDBConnection")));
            services.AddMvc(option => option.EnableEndpointRouting = false);
            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //                    .RequireAuthenticatedUser()
            //                    .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //});
            services.AddControllers();
            services.ConfigureDbContext(Configuration);
            services.InjectRepositories();
            services.InjectServices(); 

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<CarRentalDbContext>();

            //using scoped because we want the instance of CarRepository class to 
            //be alive & available the entire time of a given HTTP Request
            //when a new HTTP Request arrives at the app, another instance of C arRepository will be created
            services.AddScoped<ICarRepository, CarRepository>();
            //services.AddScoped<ICarRepository, MockCar>();
        }
 
        /// <param name="app"></param>
        /// <param name="env"></param>

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseRouting();
            

            app.UseMvc(routes =>
           {
               routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
           });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

        }

    }
}
