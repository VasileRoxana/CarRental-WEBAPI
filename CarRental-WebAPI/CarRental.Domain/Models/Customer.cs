using CarRental.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.Models
{
    public class Customer : BasePerson
    {
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
