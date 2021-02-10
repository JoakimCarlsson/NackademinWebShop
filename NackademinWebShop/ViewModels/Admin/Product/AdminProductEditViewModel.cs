using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NackademinWebShop.Attribute;
using NackademinWebShop.Models;

namespace NackademinWebShop.ViewModels.Admin.Product
{
    public class AdminProductEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You have too enter a name")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You have too enter a description")]
        [MaxLength(512, ErrorMessage = "Can't be more then 500.")]
        public string Description { get; set; }

        [Range(1, 9999999999999999.99, ErrorMessage = "The product must have a price.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The product must be either active or disabled.")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "You just choose a category.")]
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; } = new();
        public string ProductPicture { get; set; }
        public string OldName { get; set; }

        [DataType(DataType.Upload)]
        [AllowedExtensions(new[] { ".jpg", ".png", ".jpeg", ".gif" })]
        public IFormFile NewProductPicture { get; set; }
    }
}
