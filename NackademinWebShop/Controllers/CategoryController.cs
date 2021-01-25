using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NackademinWebShop.Services.CategoryServices;
using NackademinWebShop.ViewModels.Category;

namespace NackademinWebShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IActionResult Create()
        {
            CategoryCreateViewModel model = new CategoryCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _categoryServices.Create(model);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _categoryServices.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _categoryServices.Update(model); 
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
