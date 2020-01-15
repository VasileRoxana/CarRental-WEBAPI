using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Domain.Models;

namespace CarRental.Domain.Requests
{
    public class GeneralCustomerRequest
    {
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

    }
}
