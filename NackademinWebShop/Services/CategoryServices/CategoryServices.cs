using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NackademinWebShop.Models;
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
            var indexViewModels = _mapper.Map<IEnumerable<CategoryIndexViewModel>>(_categoryRepository.GetAll(includeEmpty));

            foreach (var categoryIndexViewModel in indexViewModels)
                categoryIndexViewModel.ProductCount = GetProductsCountById(categoryIndexViewModel.Id);

            return indexViewModels;
        }

        public void Create(CategoryCreateViewModel model)
        {
            Category category = _mapper.Map<Category>(model);
            _categoryRepository.Create(category);
        }

        public CategoryEditViewModel GetById(int id)
        {
            Category category = _categoryRepository.GetById(id); //Todo, check if null.
            //but this should never be null, but still good to check.

            var categoryEditViewModel = _mapper.Map<CategoryEditViewModel>(category);
            return categoryEditViewModel;
        }

        public void Update(CategoryEditViewModel model)
        {
            Category category = _mapper.Map<Category>(model);
            _categoryRepository.Update(category);
        }

        public void Delete(int id)
        {
            //todo we need too check if the category have products, if the category have products we are not allowed too delete.
            _categoryRepository.Delete(id);
        }

        public int GetProductsCountById(int id)
        {
            return _categoryRepository.GetById(id).Products.Count;
        }
    }
}
