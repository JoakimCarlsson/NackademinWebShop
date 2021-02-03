using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NackademinWebShop.Services.CategoryServices;

namespace NackademinWebShop.Areas.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesViewComponent(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IViewComponentResult Invoke()
        {
            var model = _categoryServices.GetAll(false);
            return View("Categories", model);
        }
    }
}