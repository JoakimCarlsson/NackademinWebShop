using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using NackademinWebShop.ViewModels.Admin.Product;
using NackademinWebShop.ViewModels.Products;

namespace NackademinWebShop.Services.ProductService
{
    public interface IProductServices
    {
        ProductDetailViewModel Get(int id);
        List<AdminProductViewModel> GetAll(bool includeInActive);
        List<ProductIndexViewModel> GetSearchResult(ProductSearchViewModel searchViewModel);
        AdminProductEditViewModel GetEdit(int id);
        public List<SelectListItem> GetCategoriesList();
        public void Update(AdminProductEditViewModel model);
        public void Create(AdminProductCreateViewModel model);
    }
}