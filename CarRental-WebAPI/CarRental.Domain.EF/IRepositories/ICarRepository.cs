using CarRental.Domain.Models;

namespace CarRental.Domain.EF.IRepositories
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Car GetCarById(int Id);
    }
}
