using System.Collections.Generic;
using NackademinWebShop.ViewModels.Admin.Product;
using NackademinWebShop.ViewModels.Products;

namespace NackademinWebShop.Services.ProductService
{
    public interface IProductServices
    {
        ProductIndexViewModel Get(int id);
        List<AdminProductViewModel> GetAll();
    }
}