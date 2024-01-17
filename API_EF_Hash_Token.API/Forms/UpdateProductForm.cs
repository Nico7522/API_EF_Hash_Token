namespace API_EF_Hash_Token.API.Forms
{
    public class UpdateProductForm
    {
        public string ModelName { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Sexe { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
