using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NackademinWebShop.ViewModels.Category
{
    public class CategoryCreateViewModel
    {
        [Required(ErrorMessage = "You have too enter a name")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 30.")]
        public string Name { get; set; }
    }
}
