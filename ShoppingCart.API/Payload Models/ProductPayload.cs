namespace ShoppingCartAPI.PayloadModels
{
    public class ProductPayload
    {
        public string? Name { get; set; }
        public int Price { get; set; }
        public bool InStock { get; set; }
    }
}
