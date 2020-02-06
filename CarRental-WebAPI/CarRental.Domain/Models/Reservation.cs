using CarRental.Domain.Models.BaseModels;
using System;

namespace CarRental.Domain.Models
{
    public class Reservation : BaseEntity
    {
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
