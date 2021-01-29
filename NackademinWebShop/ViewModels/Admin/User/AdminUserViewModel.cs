using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NackademinWebShop.ViewModels.Admin.UserRole;

namespace NackademinWebShop.ViewModels.Admin.User
{
    public class AdminUserViewModel
    {
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public AdminUserRoleViewModel Role { get; set; }
    }
}
