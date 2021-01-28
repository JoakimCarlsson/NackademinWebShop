using System.Collections.Generic;
using NackademinWebShop.ViewModels.Categories;

namespace NackademinWebShop.ViewModels.Admin.Category
{
    public class AdminCategoryListViewModel
    {
        public IEnumerable<CategoryIndexViewModel> Categories { get; set; }

    }
}