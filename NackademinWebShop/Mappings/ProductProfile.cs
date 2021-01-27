using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NackademinWebShop.Models;
using NackademinWebShop.ViewModels.Admin.Product;
using NackademinWebShop.ViewModels.Products;

namespace NackademinWebShop.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductIndexViewModel, Product>();
            CreateMap<Product, ProductIndexViewModel>();
            CreateMap<Product, AdminProductViewModel>();
        }
    }
}
