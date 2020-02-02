using CarRental.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.Models
{
    public class Car : BaseEntity
    {

        public Car(int id, string v1, string v2, int v3, string v4, float v5)
        {
            this.Id = id;
            this.CarName = v1;
            this.VehicleClass = v2;
            this.Capacity = v3;
            this.CarType = v4;
            this.Price = v5;
        }

        public string CarName { get; set; }
        public string VehicleClass{ get; set; }
        public int Capacity { get; set; }
        public string CarType { get; set; }
        public float Price { get; set; }
    }
}
