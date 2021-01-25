using System.Linq;
using NackademinWebShop.Data;
using NackademinWebShop.Models;

namespace NackademinWebShop.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Product Get(int id)
        {
            return _applicationDbContext.Products.FirstOrDefault(i => i.Id == id);
        }
    }
}