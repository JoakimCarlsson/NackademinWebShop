using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NackademinWebShop.ViewModels.Admin.User;

namespace NackademinWebShop.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<IdentityUser, AdminUserViewModel>();
            CreateMap<IdentityUser, AdminUserViewModel>();
            CreateMap<AdminUserViewModel, IdentityUser>();
        }
    }
}
