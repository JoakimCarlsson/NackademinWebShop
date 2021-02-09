using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NackademinWebShop.ViewModels.Admin.Category;

namespace NackademinWebShop.ViewModels.Admin.Product
{
    public class AdminProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public AdminCategoryViewModel Category { get; set; }
        public bool IsActive { get; set; }
    }
}
