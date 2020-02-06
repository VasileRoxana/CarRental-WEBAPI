using System.ComponentModel.DataAnnotations;

namespace CarRental.Domain.Models.ViewModels
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        //[RemoteAttribute(action:"IsEmailInUse", controller: "AccountController")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}