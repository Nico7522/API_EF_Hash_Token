namespace API_EF_Hash_Token.API.Forms
{
    public class ProductOrderForm
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
    }
}
