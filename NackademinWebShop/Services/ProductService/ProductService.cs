using AutoMapper;
using NackademinWebShop.Repository.ProductRepository;
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
    }
}