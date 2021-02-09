using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NackademinWebShop.Data;
using NackademinWebShop.Models;

namespace NackademinWebShop.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Category> GetAll(bool includeEmpty)
        {
            return includeEmpty ? _applicationDbContext.Categories : _applicationDbContext.Categories.Where(p => p.Products.Count != 0);
        }

        public Category GetById(int id)
        {
            return _applicationDbContext.Categories.Include(p => p.Products.Where(p => p.IsActive)).FirstOrDefault(c => c.Id == id);
        }

        public void Update(Category category)
        {
            _applicationDbContext.Categories.Update(category);
            _applicationDbContext.SaveChanges();
        }
        public void Create(Category category)
        {
            _applicationDbContext.Categories.Add(category);
            _applicationDbContext.SaveChanges();
        }
    }
}
