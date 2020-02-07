using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.Models;
using System.Collections.Generic;

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

        public List<Reservation> GetReservationsByUserId(string Id)
        {
            List<Reservation> reservations = new List<Reservation>();
            foreach (var e in context.Reservations)
            {
                if (e.UserId == Id)
                {
                    reservations.Add(e);
                }
            }
            return reservations;
        }
    }
}
