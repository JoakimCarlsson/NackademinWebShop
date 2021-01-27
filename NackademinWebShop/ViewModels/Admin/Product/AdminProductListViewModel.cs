using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NackademinWebShop.ViewModels.Admin.Product
{
    public class AdminProductListViewModel
    {
        public IEnumerable<AdminProductViewModel> Products { get; set; }
    }
}
