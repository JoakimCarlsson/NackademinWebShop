using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NackademinWebShop.Services.CategoryServices;
using NackademinWebShop.ViewModels.Admin.Category;
using NackademinWebShop.ViewModels.Categories;

namespace NackademinWebShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IActionResult Index(int id)
        {
            var model = _categoryServices.Get(id);
            return View(model);
        }

        [Authorize(Roles = "Administrator,Product Manager")]
        public IActionResult Create()
        {
            AdminCategoryCreateViewModel model = new AdminCategoryCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Product Manager")]
        public IActionResult Create(AdminCategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _categoryServices.Create(model);
                return RedirectToAction("Index", "Home");
                //ModelState.AddModelError(); //TODO FIX ME. :')
            }

            return View(model);
        }

        [Authorize(Roles = "Administrator,Product Manager")]
        public IActionResult Edit(int id)
        {
            var model = _categoryServices.GetById(id);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Product Manager")]
        public IActionResult Edit(AdminCategoryEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _categoryServices.Update(model);
                return RedirectToAction("GetAll");
            }

            return View(model);
        }

        public IActionResult GetAll()
        {
            var model = new AdminCategoryListViewModel {Categories = _categoryServices.GetAll(true)};
            return View(model);
        }
    }
}
