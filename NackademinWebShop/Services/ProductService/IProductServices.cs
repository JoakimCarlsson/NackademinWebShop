using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using NackademinWebShop.ViewModels.Admin.Product;
using NackademinWebShop.ViewModels.Products;

namespace NackademinWebShop.Services.ProductService
{
    public interface IProductServices
    {
        ProductIndexViewModel Get(int id);
        List<AdminProductViewModel> GetAll();
        AdminProductEditViewModel GetEdit(int id);
        public List<SelectListItem> GetCategoriesList();
        public void Update(AdminProductEditViewModel model);
        public void Create(AdminProductCreateViewModel model);
        public void Delete(int id);
    }
}