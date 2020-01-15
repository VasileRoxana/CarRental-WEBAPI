using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.Models;

namespace CarRental.Domain.EF.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(CarRentalDbContext context) : base(context)
        { 
        }
    }
}
