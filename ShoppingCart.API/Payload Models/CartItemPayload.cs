namespace ShoppingCartAPI.PayloadModels
{
    public class CartItemPayload
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int? Quantity { get; set; } = 1;
    }
}
