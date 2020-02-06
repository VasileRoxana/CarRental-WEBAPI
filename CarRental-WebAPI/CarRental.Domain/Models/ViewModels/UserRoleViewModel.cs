using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.Models.ViewModels
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
