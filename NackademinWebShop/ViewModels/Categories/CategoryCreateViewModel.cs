using System.ComponentModel.DataAnnotations;

namespace NackademinWebShop.ViewModels.Categories
{
    public class CategoryCreateViewModel
    {
        [Required(ErrorMessage = "You have too enter a name")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 30.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "The name can't have numbers in it. And must start with an uppercase letter.")]
        public string Name { get; set; }
    }
}
