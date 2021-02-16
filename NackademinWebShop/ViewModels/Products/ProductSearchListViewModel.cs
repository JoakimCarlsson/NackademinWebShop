using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NackademinWebShop.ViewModels.Admin.Product;

namespace NackademinWebShop.ViewModels.Products
{
    public class ProductSearchListViewModel
    {
        public List<ProductIndexViewModel> Products { get; set; }
        public string SearchWord { get; set; }
    }
}
