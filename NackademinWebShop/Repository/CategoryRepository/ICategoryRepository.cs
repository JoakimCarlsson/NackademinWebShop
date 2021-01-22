using System.Collections.Generic;
using NackademinWebShop.Models;

namespace NackademinWebShop.Repository.CategoryRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll(bool includeEmpty);
        Category GetById(int id);
        void Update(Category category);
        void Delete(Category category);
    }
}