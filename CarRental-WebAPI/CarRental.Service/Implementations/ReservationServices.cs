using CarRental.Domain.EF;
using CarRental.Domain.EF.IRepositories;
using CarRental.Services.Implementations;
using CarRental.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Service.Implementations
{
    public class ReservationServices : BaseServices, IReservationServices
    {
        public IReservationRepository ReservationRepository { get; }
        public ReservationServices(CarRentalDbContext context, IReservationRepository reservationRepository) : base(context)
        {
            ReservationRepository = reservationRepository;
        }
    }
}
