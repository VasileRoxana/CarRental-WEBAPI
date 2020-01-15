using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.EF.Repositories
{
   public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(CarRentalDbContext context) : base(context)
        {
        }
    }
}
