using NackademinWebShop.Models;

namespace NackademinWebShop.Repository.ProductRepository
{
    public interface IProductRepository
    {
        Product Get(int id);
    }
}