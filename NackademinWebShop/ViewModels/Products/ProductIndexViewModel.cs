using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NackademinWebShop.ViewModels.Products
{
    public class ProductIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProductPicture { get; set; }
    }
}
