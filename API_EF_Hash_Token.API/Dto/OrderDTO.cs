namespace API_EF_Hash_Token.API.Dto
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public UserDTO User { get; set; }
        public List<ProductOrderDTO> OrderedProducts { get; set; } = new List<ProductOrderDTO>();
        public decimal TotalPrice { get; set; }
        public decimal TotalReduction { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
