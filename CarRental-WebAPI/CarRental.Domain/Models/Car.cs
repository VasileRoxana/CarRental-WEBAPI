using CarRental.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.Models
{
    public class Car : BaseEntity
    {
        public int CarName { get; set; }
        public string VehicleClass{ get; set; }
        public int Capacity { get; set; }
        public string CarType { get; set; }
        public float Price { get; set; }
    }
}
