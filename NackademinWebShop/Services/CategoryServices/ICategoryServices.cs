using System.Collections.Generic;
using NackademinWebShop.ViewModels.Admin.Category;
using NackademinWebShop.ViewModels.Categories;

namespace NackademinWebShop.Services.CategoryServices
{
    public interface ICategoryServices
    {
        IEnumerable<CategoryIndexViewModel> GetAll(bool includeEmpty);
        void Create(AdminCategoryCreateViewModel model);
        bool NameExists(string name);
        AdminCategoryEditViewModel GetById(int id);
        CategoryListIndexViewModel GetProductsInCategory(int id, string sortOrder); //TODO FIX ME
        void Update(AdminCategoryEditViewModel model);
    }
}