using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NackademinWebShop.Controllers
{
    public class AdministrationController : Controller
    {
        [Authorize(Roles = "Administrator,Product Manager")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
