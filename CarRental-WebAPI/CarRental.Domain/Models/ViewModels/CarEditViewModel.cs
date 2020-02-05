using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.Models.ViewModels
{
    public class CarEditViewModel : CarCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }

    }
}
