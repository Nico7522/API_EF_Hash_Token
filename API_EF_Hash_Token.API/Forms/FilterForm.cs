namespace API_EF_Hash_Token.API.Forms
{
    public class FilterForm
    {
        public string? ModelName { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? Sexe { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
