using CarRental.Domain.EF.IRepositories;

namespace CarRental.Services.Interfaces
{
    public interface IReservationServices : IBaseServices
    {
        IReservationRepository ReservationRepository { get; }

    }

}
