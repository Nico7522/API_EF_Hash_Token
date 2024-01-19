namespace API_EF_Hash_Token.API.Dto
{
    public class ProductDTO
    {
        public int ProductId { get; init; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Sexe { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public List<SizeStockDTO> Sizes { get; set; }
    }
}
