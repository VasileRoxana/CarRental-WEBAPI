using CarRental.Domain.Models;

namespace CarRental.Domain.EF.IRepositories
{
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        Reservation GetReservationByUserId(int Id);
        Reservation Add(Reservation reservation);
        Reservation Delete(int Id);
    }
}
