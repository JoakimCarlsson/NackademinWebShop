using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NackademinWebShop.Models;
using NackademinWebShop.ViewModels.Categories;

namespace NackademinWebShop.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryIndexViewModel>();
            CreateMap<CategoryIndexViewModel, Category>();
            CreateMap<CategoryCreateViewModel, Category>();
            CreateMap<CategoryEditViewModel, Category>();
            CreateMap<Category, CategoryEditViewModel>();
            CreateMap<Category, CategoryListIndexViewModel>();
        }
    }
}
