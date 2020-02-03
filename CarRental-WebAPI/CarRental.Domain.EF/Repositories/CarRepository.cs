using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.EF.Repositories
{
   public class CarRepository : BaseRepository<Car>, ICarRepository
    {

        public CarRepository(CarRentalDbContext context) : base(context){ }

        public Car Add(Car car)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Car GetCarById(int Id)
        {
            throw new NotImplementedException();
        }

        //public Car GetCarById(int Id)
        //{
        //    //CarRentalDbContext dbContext = new CarRentalDbContext;
        //    //return dbContext.Cars.Find(Id);

        //    return ;
        //}
    }
}
