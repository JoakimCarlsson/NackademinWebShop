using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NackademinWebShop.ViewModels.Admin.UserRole;

namespace NackademinWebShop.ViewModels.Admin.User
{
    public class AdminUserEditViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public AdminUserRoleViewModel Role { get; set; }
    }
}
