using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NackademinWebShop.Models;
using NackademinWebShop.ViewModels.Admin.Category;
using NackademinWebShop.ViewModels.Categories;

namespace NackademinWebShop.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryIndexViewModel>();
            CreateMap<Category, AdminCategoryViewModel>();
            CreateMap<CategoryIndexViewModel, Category>();
            CreateMap<AdminCategoryCreateViewModel, Category>();
            CreateMap<AdminCategoryEditViewModel, Category>();
            CreateMap<Category, AdminCategoryEditViewModel>();
            CreateMap<Category, CategoryListIndexViewModel>();
            CreateMap<Category, AdminCategoryViewModel>();
            CreateMap<AdminCategoryViewModel, Category>();
        }
    }
}
