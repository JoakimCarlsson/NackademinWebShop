using System.Collections.Generic;
using NackademinWebShop.ViewModels.Products;

namespace NackademinWebShop.ViewModels.Categories
{
    public class CategoryListIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int ProductCount { get; set; }
        public List<ProductIndexViewModel> Products { get; set; }
    }
}
