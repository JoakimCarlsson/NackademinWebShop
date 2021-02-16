using Microsoft.AspNetCore.Http;
using NackademinWebShop.ViewModels.Categories;

namespace NackademinWebShop.ViewModels.Products
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductPicture { get; set; }
        public CategoryIndexViewModel Category { get; set; }
    }
}