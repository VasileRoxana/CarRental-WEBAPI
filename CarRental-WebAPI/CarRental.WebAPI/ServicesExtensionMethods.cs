using CarRental.Domain.EF;
using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.EF.Repositories;
using CarRental.Service.Implementations;
using CarRental.Service.Interfaces;
using CarRental.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.WebAPI
{
    public static class ServicesExtensionMethods
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config["ConnectionStrings:CarRentalWebAPIContextConnection"];
            services.AddDbContext < CarRentalDbContext>(c => c.UseSqlServer(connectionString, b => b.MigrationsAssembly("CarRental.WebAPI")));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<ICarServices, CarServices>();
            services.AddScoped<IReservationServices, ReservationServices>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<ICustomerServices, CustomerServices>();
        }
    }
}
