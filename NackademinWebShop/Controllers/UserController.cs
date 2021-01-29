using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NackademinWebShop.Services.UserService;
using NackademinWebShop.ViewModels.Admin.User;

namespace NackademinWebShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;

        public UserController(IUserService userService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signManager = signManager;
        }

        public IActionResult GetAll()
        {
            var model = new AdminUserListViewModel {Users = _userService.GetUsers()};

            return View(model);
        }

        public IActionResult Register()
        {
            var model = new AdminUserRegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(AdminUserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email};
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
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
            return View(model);
        }

        //TODO FIX ME:
        public async Task<IActionResult> Delete(string id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userId == id)
            {
                ModelState.AddModelError("", "You can't delete your own user.");
                return RedirectToAction("GetAll");
            }
            var user = _userManager.Users.FirstOrDefault(p => p.Id == id);

            var result = await _userManager.DeleteAsync(user);

            return RedirectToAction("GetAll");
        }
    }
}
