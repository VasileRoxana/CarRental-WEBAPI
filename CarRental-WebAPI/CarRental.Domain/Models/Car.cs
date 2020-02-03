using CarRental.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRental.Domain.Models
{
    public class Car : BaseEntity
    {

        public Car(int id, string v1, CarClass v2, int v3, CarType v4, float v5, string photo)
        {
            this.Id = id;
            this.CarName = v1;
            this.VehicleClass = v2;
            this.Capacity = v3;
            this.CarType = v4;
            this.Price = v5;
            this.PhotoPath = photo;
        }

        public Car() { }

        // The required fields need to be mandatory
        [Required]
        public string CarName { get; set; }
        [Required]
        public CarClass? VehicleClass { get; set; }
        [Required]
        public int? Capacity { get; set; }
        [Required]
        public CarType? CarType { get; set; }
        [Required]
        public float? Price { get; set; }
        [Required]
        public string PhotoPath { get; set; }
    }
}
