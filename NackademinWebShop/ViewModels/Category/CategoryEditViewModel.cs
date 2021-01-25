using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NackademinWebShop.ViewModels.Category
{
    public class CategoryEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You have too enter a name")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 30.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "The name can't have numbers in it, and must start with an uppercase letter.")]
        public string Name { get; set; }
    }
}
