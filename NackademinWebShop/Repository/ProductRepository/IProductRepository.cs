using System.Collections.Generic;
using NackademinWebShop.Models;

namespace NackademinWebShop.Repository.ProductRepository
{
    public interface IProductRepository
    {
        Product Get(int id);
        IEnumerable<Product> GetAll(bool includeInActive);
        void Update(Product product);
        void Create(Product product);
    }
}