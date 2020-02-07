using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.Models;

namespace CarRental.Domain.EF.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        private readonly CarRentalDbContext context;
        public ReservationRepository(CarRentalDbContext context) : base(context)
        {
            this.context = context;
        }

        public Reservation Add(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
            return reservation;
        }

        public Reservation Delete(int id)
        {
            Reservation reservation = context.Reservations.Find(id);
            if (reservation != null)
            {
                context.Reservations.Remove(reservation);
                context.SaveChanges();
            }
            return reservation;
        }

        public Reservation GetReservationByUserId(string Id)
        {
            foreach(var e in context.Reservations)
            {
                if (e.UserId == Id)
                {
                    return e;
                }
            }
            return null;
            
        }
    }
}
