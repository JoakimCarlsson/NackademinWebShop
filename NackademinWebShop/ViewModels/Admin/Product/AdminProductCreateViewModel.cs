using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using NackademinWebShop.Attribute;

namespace NackademinWebShop.ViewModels.Admin.Product
{
    public class AdminProductCreateViewModel
    {
        [Required(ErrorMessage = "You have too enter a name")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You have too enter a description")]
        [MaxLength(512, ErrorMessage = "Can't be more then 500.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The product must have a price.")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Price can't be more then 9999999999999999.99")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The product must be either active or disabled.")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "You just choose a category.")]
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; } = new();

        [Required(ErrorMessage = "Please choose product image")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new[] { ".jpg", ".png", ".jpeg", ".gif" })]
        public IFormFile ProductPicture { get; set; }
    }
}
