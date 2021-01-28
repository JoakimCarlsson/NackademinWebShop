using System.Collections.Generic;
using NackademinWebShop.ViewModels.Admin.Category;
using NackademinWebShop.ViewModels.Categories;

namespace NackademinWebShop.Services.CategoryServices
{
    public interface ICategoryServices
    {
        IEnumerable<CategoryIndexViewModel> GetAll(bool includeEmpty);
        void Create(AdminCategoryCreateViewModel model);
        AdminCategoryEditViewModel GetById(int id);
        CategoryListIndexViewModel Get(int id); //TODO FIX ME
        void Update(AdminCategoryEditViewModel model);
        void Delete(int id);
    }
}