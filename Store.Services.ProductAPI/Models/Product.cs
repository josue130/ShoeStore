using System.ComponentModel.DataAnnotations;

namespace Store.Services.ProductAPI.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 1000)]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
