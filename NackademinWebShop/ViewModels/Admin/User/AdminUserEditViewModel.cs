using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using NackademinWebShop.ViewModels.Admin.UserRole;

namespace NackademinWebShop.ViewModels.Admin.User
{
    public class AdminUserEditViewModel
    {
        public string Id { get; set; }
        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Roles")]
        public List<string> CurrentRoles { get; set; }
        public List<SelectListItem> AllRoles { get; set; }
    }
}
