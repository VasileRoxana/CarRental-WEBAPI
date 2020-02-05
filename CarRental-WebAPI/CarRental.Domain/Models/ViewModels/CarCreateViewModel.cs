using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRental.Domain.Models.ViewModels
{
    public class CarCreateViewModel
    {
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
        public IFormFile Photo { get; set; }
    }
}
