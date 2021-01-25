using NackademinWebShop.ViewModels.Products;

namespace NackademinWebShop.Services.ProductService
{
    public interface IProductServices
    {
        ProductIndexViewModel Get(int id);
    }
}