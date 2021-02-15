using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NackademinWebShop.Models;
using NackademinWebShop.Repository.CategoryRepository;
using NackademinWebShop.ViewModels.Admin.Category;
using NackademinWebShop.ViewModels.Categories;

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

        public void Create(AdminCategoryCreateViewModel model)
        {
            Category category = _mapper.Map<Category>(model);
            _categoryRepository.Create(category);
        }

        public AdminCategoryEditViewModel GetById(int id)
        {
            Category category = _categoryRepository.GetById(id);
            var categoryEditViewModel = _mapper.Map<AdminCategoryEditViewModel>(category);
            return categoryEditViewModel;
        }

        public CategoryListIndexViewModel Get(int id)
        {
            return _mapper.Map<CategoryListIndexViewModel>(_categoryRepository.GetById(id));
        }

        public void Update(AdminCategoryEditViewModel model)
        {
            Category category = _mapper.Map<Category>(model);
            _categoryRepository.Update(category);
        }

        public int GetProductsCountById(int id)
        {
            return _categoryRepository.GetById(id).Products.Count;
        }
    }
}
