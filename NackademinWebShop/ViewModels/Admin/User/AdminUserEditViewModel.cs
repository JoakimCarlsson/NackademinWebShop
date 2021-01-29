using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NackademinWebShop.ViewModels.Admin.UserRole;

namespace NackademinWebShop.ViewModels.Admin.User
{
    public class AdminUserEditViewModel
    {
        public string Id { get; set; }
        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public AdminUserRoleViewModel Role { get; set; }
    }
}
