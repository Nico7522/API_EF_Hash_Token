namespace API_EF_Hash_Token.API.Dto
{
    public class OrderResponseDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ProductOrderResponseDTO> Products { get; set; } = new List<ProductOrderResponseDTO>();
    }
}
