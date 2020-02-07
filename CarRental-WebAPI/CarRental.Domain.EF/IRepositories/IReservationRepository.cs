using CarRental.Domain.Models;
using System.Collections.Generic;

namespace CarRental.Domain.EF.IRepositories
{
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        List<Reservation> GetReservationsByUserId(string Id);
        Reservation Add(Reservation reservation);
        Reservation Delete(int Id);
    }
}
