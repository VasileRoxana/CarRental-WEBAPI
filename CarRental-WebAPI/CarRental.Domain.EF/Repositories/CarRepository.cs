using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.EF.Repositories
{
   public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        private readonly CarRentalDbContext context;
        public CarRepository(CarRentalDbContext context) : base(context)
        {
            this.context = context;
        }

        public Car Add(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
            return car;
        }

        public Car Delete(int id)
        {
            Car car = context.Cars.Find(id);
            if(car != null)
            {
                context.Cars.Remove(car);
                context.SaveChanges();
            }
            return car;
        }
        public IEnumerable<Car> GetAllCars()
        {
            if (context != null)
            { 
                return context.Cars;
            }
            return null;
        }

        public Car GetCarById(int Id)
        {
            return context.Cars.Find(Id);
        }

        public Car Update(Car carChanges)
        {
            var car = context.Cars.Attach(carChanges);
            car.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return carChanges;
        }
    }
}
