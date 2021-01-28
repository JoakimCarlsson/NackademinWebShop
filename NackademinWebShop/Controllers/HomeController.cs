using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NackademinWebShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NackademinWebShop.Services.CategoryServices;
using NackademinWebShop.Services.ProductService;
using NackademinWebShop.ViewModels.Products;

namespace NackademinWebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _productServices;

        public HomeController(ILogger<HomeController> logger, IProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }

        public IActionResult Index(string search)
        {
            var model = new ProductListIndexViewModel {Products = _productServices.GetSearchResult(search)};
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
