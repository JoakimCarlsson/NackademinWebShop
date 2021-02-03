using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using NackademinWebShop.Models;
using NackademinWebShop.Repository.CategoryRepository;
using NackademinWebShop.Repository.ProductRepository;
using NackademinWebShop.ViewModels.Admin.Product;
using NackademinWebShop.ViewModels.Products;

namespace NackademinWebShop.Services.ProductService
{
    public class ProductService : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public ProductIndexViewModel Get(int id)
        {
            return _mapper.Map<ProductIndexViewModel>(_productRepository.Get(id));
        }

        public List<AdminProductViewModel> GetAll()
        {
            List<AdminProductViewModel> test = new List<AdminProductViewModel>();
            foreach (Product product in _productRepository.GetAll())
            {
                var tmp = _mapper.Map<AdminProductViewModel>(product);
                test.Add(tmp);
            }

            return test;
        }

        public List<ProductIndexViewModel> GetSearchResult(string query, string sortOrder)
        {
            var products = _productRepository.GetAll();
            var model = _mapper.Map<List<ProductIndexViewModel>>(products.Where(i => query == null||i.Name.ToLower().Contains(query.ToLower()) || i.Description.ToLower().Contains(query.ToLower())).ToList());

            string test = query;

            if (sortOrder == "asc")
                return model.OrderBy(p => p.Price).ToList();
            if (sortOrder == "desc")
                return model.OrderByDescending(p => p.Price).ToList();

            return model;
        }

        public AdminProductEditViewModel GetEdit(int id)
        {
            var model = _mapper.Map<AdminProductEditViewModel>(_productRepository.Get(id));
            model.Categories = GetCategoriesList();
            return model;
        }

        public List<SelectListItem> GetCategoriesList()
        {
            var categories = _categoryRepository.GetAll(true);
            var list = new List<SelectListItem>();
            list.AddRange(categories.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            }));

            return list;
        }

        public void Update(AdminProductEditViewModel model)
        {
            var product = _mapper.Map<Product>(model);
            product.Category = _categoryRepository.GetById(model.CategoryId); //TODO CHECK ME
            _productRepository.Update(product);
        }

        public void Create(AdminProductCreateViewModel model)
        {
            var product = _mapper.Map<Product>(model);
            product.Category = _categoryRepository.GetById(model.CategoryId);
            _productRepository.Create(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}