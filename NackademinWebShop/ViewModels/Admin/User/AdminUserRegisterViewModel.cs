using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NackademinWebShop.ViewModels.Admin.User
{
    public class AdminUserRegisterViewModel
    {
        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.EmailAddress), Compare(nameof(Email))]
        public string ConfirmEmail { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        public List<string> Roles { get; set; }
    }
}
