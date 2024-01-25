namespace API_EF_Hash_Token.API.Dto
{
    public class ProductOrderDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public SizeDTO Size { get; set; }
        public decimal ReductionPerProduct { get; set; }

    }
}
