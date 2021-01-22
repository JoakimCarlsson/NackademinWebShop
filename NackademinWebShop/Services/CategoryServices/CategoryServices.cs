using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NackademinWebShop.Repository.CategoryRepository;
using NackademinWebShop.ViewModels.Category;

namespace NackademinWebShop.Services.CategoryServices
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryIndexViewModel> GetAll(bool includeEmpty)
        {
            var temp = _mapper.Map<IEnumerable<CategoryIndexViewModel>>(_categoryRepository.GetAll(includeEmpty));
            foreach (var categoryIndexViewModel in temp)
                categoryIndexViewModel.ProductCount = GetProductsCountById(categoryIndexViewModel.Id);

            return temp;
        }

        public int GetProductsCountById(int id)
        {
            return _categoryRepository.GetById(id).Products.Count;
        }
    }
}
