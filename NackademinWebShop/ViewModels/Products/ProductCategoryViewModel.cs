using NackademinWebShop.ViewModels.Categories;

namespace NackademinWebShop.ViewModels.Products
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProductPicture { get; set; }
    }
}