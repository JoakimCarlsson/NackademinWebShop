using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NackademinWebShop.Data;
using NackademinWebShop.ViewModels.Admin.User;
using NackademinWebShop.ViewModels.Admin.UserRole;

namespace NackademinWebShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public UserController(UserManager<IdentityUser> userManager, IMapper mapper, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public IActionResult Register()
        {
            var model = new AdminUserRegisterViewModel {Roles = _dbContext.Roles.Select(i => i.Name).ToList()};
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(AdminUserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email, EmailConfirmed = true};
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    foreach (string role in model.Roles)
                    {
                        await _userManager.AddToRoleAsync(user, role);
                    }
                    return RedirectToAction("GetAll");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            model.Roles = _dbContext.Roles.Select(i => i.Name).ToList();
            return View(model);
        }

        public async Task<IActionResult> GetAll()
        {
            //TODO needs cleaning up.
            var model = new AdminUserListViewModel();
            List<AdminUserViewModel> users = new List<AdminUserViewModel>();

            foreach (IdentityUser user in _userManager.Users)
            {
                var test = _mapper.Map<AdminUserViewModel>(user);
                test.Roles = new List<AdminUserRoleViewModel>();

                var roles = await _userManager.GetRolesAsync(user);

                foreach (string role in roles)
                {
                    test.Roles.Add(new AdminUserRoleViewModel { Name = role });
                }
                users.Add(test);
            }

            model.Users = users;
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = new AdminUserEditViewModel();
            var user = _userManager.Users.FirstOrDefault(i => i.Id == id);
            model.Email = user.Email;
            model.Id = user.Id;

            var activeRoles = await _userManager.GetRolesAsync(user);
            model.AllRoles = GetAllRoles((List<string>) activeRoles);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminUserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(i => i.Id == model.Id);

                await _userManager.RemoveFromRolesAsync(user, _dbContext.Roles.Select(n => n.Name));
                await _userManager.AddToRolesAsync(user, model.CurrentRoles);

                user.EmailConfirmed = true;
                await _userManager.SetEmailAsync(user, model.Email);
                await _userManager.SetUserNameAsync(user, model.Email);

                return RedirectToAction("GetAll");
            }

            model.AllRoles = GetAllRoles(model.CurrentRoles);
            return View(model);
        }

        private List<SelectListItem> GetAllRoles(List<string> activeRoles)
        {
            var roles = _dbContext.Roles;
            var list = new List<SelectListItem>();
            list.AddRange(roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Name,
                Selected = activeRoles.Contains(r.Name)
            }));

            return list;
        }
    }
}
