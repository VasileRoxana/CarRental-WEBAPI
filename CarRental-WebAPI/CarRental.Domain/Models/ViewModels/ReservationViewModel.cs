using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.Models.ViewModels
{
    public class ReservationViewModel
    {
        public int CarId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
