using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NackademinWebShop.Services.ProductService;
using NackademinWebShop.ViewModels.Products;

namespace NackademinWebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        public IActionResult Index(int id)
        {
            var model = _productServices.Get(id);
            return View(model);
        }
    }
}
