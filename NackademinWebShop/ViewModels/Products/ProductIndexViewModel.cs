using NackademinWebShop.ViewModels.Categories;

namespace NackademinWebShop.ViewModels.Products
{
    public class ProductIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CategoryIndexViewModel Category { get; set; }
    }
}