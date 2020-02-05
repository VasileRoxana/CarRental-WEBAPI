using CarRental.Domain.EF.ModelConfigurations;
using CarRental.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Domain.EF
{
    public class CarRentalDbContext : IdentityDbContext
    {
        public CarRentalDbContext(DbContextOptions <CarRentalDbContext> options) : 
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 20,
                    CarName = "BMW M5",
                    VehicleClass = CarClass.B,
                    Capacity = 2412,
                    CarType = CarType.Cabrio,
                    Price = 251,
                    PhotoPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQAm1C05DaazFiRWcfM3m8FqayaOa-T64ushgHosW4gZwoJXUp1"
                },
                new Car
                {
                    Id = 2,
                    CarName = "BMW M1",
                    VehicleClass = CarClass.A,
                    Capacity = 1242,
                    CarType = CarType.Break,
                    Price = 2511,
                    PhotoPath = "https://www.autocar.co.uk/sites/autocar.co.uk/files/styles/body-image/public/911-road-3629a.jpg?itok=m6x23Go0"
                }
                );
        }
          
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
