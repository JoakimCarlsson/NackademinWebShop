using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            return _applicationDbContext.Products.Include(c => c.Category).FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Product> GetAll(bool includeInActive)
        {
            return includeInActive ? _applicationDbContext.Products.Include(c => c.Category) : _applicationDbContext.Products.Include(c => c.Category).Where(a => a.IsActive);
        }

        public void Update(Product product)
        {
            _applicationDbContext.Products.Update(product);
            _applicationDbContext.SaveChanges();
        }

        public void Create(Product product)
        {
            _applicationDbContext.Products.Add(product);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            //TODO WE CAN MAKE THIS LOOK BETTER PROBABLY
            var product = _applicationDbContext.Products.FirstOrDefault(p => p.Id == id);
            _applicationDbContext.Products.Remove(product);
            _applicationDbContext.SaveChanges();
        }
    }
}