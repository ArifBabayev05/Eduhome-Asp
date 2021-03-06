using System;
using System.ComponentModel.DataAnnotations;

namespace Business.ViewModels
{
    public class RegisterVM
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required, MaxLength(100),DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string Username { get; set; }
        [Required, MaxLength(100), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, MaxLength(100), DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}

