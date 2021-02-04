using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NackademinWebShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MaxLength(512)]
        public string Description { get; set; }
        [Required]
        [Range(0, 9999999999999999.99)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required] 
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }
    }
}