using System.Collections.Generic;
using NackademinWebShop.ViewModels.Categories;

namespace NackademinWebShop.Services.CategoryServices
{
    public interface ICategoryServices
    {
        IEnumerable<CategoryIndexViewModel> GetAll(bool includeEmpty);
        void Create(CategoryCreateViewModel model);
        CategoryEditViewModel GetById(int id);
        CategoryListIndexViewModel Get(int id); //TODO FIX ME
        void Update(CategoryEditViewModel model);
        void Delete(int id);
    }
}