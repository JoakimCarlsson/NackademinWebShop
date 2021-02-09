using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NackademinWebShop.Services.ProductService;
using NackademinWebShop.ViewModels.Admin.Product;
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
        public IActionResult Detail(int id)
        {
            var model = _productServices.Get(id);
            return View(model);
        }

        [Authorize(Roles = "Administrator,Product Manager")]
        public IActionResult GetAll()
        {
            var model = new AdminProductListViewModel
            {
                Products = _productServices.GetAll()
            };
            return View(model);
        }

        [Authorize(Roles = "Administrator,Product Manager")]
        public IActionResult Edit(int id)
        {
            AdminProductEditViewModel model = _productServices.GetEdit(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Product Manager")]
        public IActionResult Edit(AdminProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productServices.Update(model);
                return RedirectToAction("GetAll");
            }

            model.Categories = _productServices.GetCategoriesList();
            return View(model);
        }

        [Authorize(Roles = "Administrator,Product Manager")]
        public IActionResult Create()
        {
            var model = new AdminProductCreateViewModel { Categories = _productServices.GetCategoriesList() };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Product Manager")]
        public IActionResult Create(AdminProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productServices.Create(model);
                return RedirectToAction("GetAll");
            }

            model.Categories = _productServices.GetCategoriesList();
            return View(model);
        }
    }
}
