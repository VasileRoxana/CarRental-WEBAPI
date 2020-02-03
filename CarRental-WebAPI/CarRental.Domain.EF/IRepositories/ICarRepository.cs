using CarRental.Domain.Models;
using System.Collections.Generic;

namespace CarRental.Domain.EF.IRepositories
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Car GetCarById(int Id);
        IEnumerable<Car> GetAllCars();
        Car Add(Car car);
        Car Update(Car carChanges);
        Car Delete(int Id);
    }
}
