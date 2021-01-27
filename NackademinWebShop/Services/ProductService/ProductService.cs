using System.Collections.Generic;
using AutoMapper;
using NackademinWebShop.Models;
using NackademinWebShop.Repository.ProductRepository;
using NackademinWebShop.ViewModels.Admin.Product;
using NackademinWebShop.ViewModels.Products;

namespace NackademinWebShop.Services.ProductService
{
    public class ProductService : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
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
    }
}