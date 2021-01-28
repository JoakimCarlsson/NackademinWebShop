using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NackademinWebShop.ViewModels.Admin.Product;

namespace NackademinWebShop.ViewModels.Products
{
    public class ProductListIndexViewModel
    {
        public string Search { get; set; }
        public List<ProductIndexViewModel> Products { get; set; }
    }
}
