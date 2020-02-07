using CarRental.Domain.Models.BaseModels;
using System;

namespace CarRental.Domain.Models
{
    public class Reservation : BaseEntity
    {
        public string UserId { get; set; }
        public int CarId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        
    }
}
