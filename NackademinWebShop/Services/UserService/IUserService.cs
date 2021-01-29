using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NackademinWebShop.ViewModels.Admin.User;

namespace NackademinWebShop.Services.UserService
{
    public interface IUserService
    {
        public IdentityUser GetUser(string email);
        public List<AdminUserViewModel> GetUsers();
    }

    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
            _mapper = mapper;
        }

        public IdentityUser GetUser(string email)
        {
           return _userManager.Users.FirstOrDefault(p => p.Email == email);
        }

        public List<AdminUserViewModel> GetUsers()
        {
            List<AdminUserViewModel> users = new List<AdminUserViewModel>();

            foreach (IdentityUser user in _userManager.Users)
            {
                users.Add(_mapper.Map<AdminUserViewModel>(user));
            }

            return users;
        }
    }
}
