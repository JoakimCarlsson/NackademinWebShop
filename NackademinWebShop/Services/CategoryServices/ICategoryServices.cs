using System.Collections.Generic;
using NackademinWebShop.ViewModels.Category;

namespace NackademinWebShop.Services.CategoryServices
{
    public interface ICategoryServices
    {
        IEnumerable<CategoryIndexViewModel> GetAll(bool includeEmpty);
        void Create(CategoryCreateViewModel model);
    }
}