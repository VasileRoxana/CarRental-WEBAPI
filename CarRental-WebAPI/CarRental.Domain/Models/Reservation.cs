using CarRental.Domain.Models.BaseModels;
using System;

namespace CarRental.Domain.Models
{
    public class Reservation : BaseEntity
    {
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int VehicleClass { get; set; }
        public string Status { get; set; }
    }
}
