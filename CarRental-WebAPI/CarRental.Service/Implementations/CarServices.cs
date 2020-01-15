using CarRental.Domain.EF;
using CarRental.Domain.EF.IRepositories;
using CarRental.Service.Interfaces;
using CarRental.Services.Implementations;

namespace CarRental.Service.Implementations
{
    public class CarServices : BaseServices, ICarServices
    {
        public ICarRepository CarRepository { get; }
        public CarServices(CarRentalDbContext context, ICarRepository carRepository) : base(context)
        {
            CarRepository = carRepository;
        }
    }
}
