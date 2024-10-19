namespace Store.Services.ShoppingCartAPI.Models.Dto
{
    public class CartHeaderDto
    {
        public Guid CartHeaderId { get; set; }
        public string? UserId { get; set; }
        public double Discount { get; set; }
        public double CartTotal { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
