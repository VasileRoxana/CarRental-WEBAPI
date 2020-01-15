using CarRental.Domain.EF.IRepositories;
using CarRental.Services.Interfaces;

namespace CarRental.Service.Interfaces
{
    public interface ICarServices : IBaseServices
    {
        ICarRepository CarRepository { get; }
    }
}
