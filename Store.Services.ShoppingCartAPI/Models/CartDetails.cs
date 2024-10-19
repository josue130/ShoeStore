using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Services.ShoppingCartAPI.Models
{
    public class CartDetails
    {
        [Key]
        public Guid CartDetailsId { get; set; }
        public Guid CartHeaderId { get; set; }
        [ForeignKey("CartHeaderId")]
        public CartHeader CartHeader { get; set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }

    }
}
