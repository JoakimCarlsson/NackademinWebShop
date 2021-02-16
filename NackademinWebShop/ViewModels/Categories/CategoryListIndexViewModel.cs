using System.Collections.Generic;
using NackademinWebShop.ViewModels.Products;

namespace NackademinWebShop.ViewModels.Categories
{
    public class CategoryListIndexViewModel
    {
        public string Name { get; set; }
        public List<ProductCategoryViewModel> Products { get; set; }
    }
}
