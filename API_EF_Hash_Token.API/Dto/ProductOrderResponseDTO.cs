namespace API_EF_Hash_Token.API.Dto
{
    public class ProductOrderResponseDTO
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal ReductionPerProduct { get; set; }
    }
}
