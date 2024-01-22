using System.ComponentModel.DataAnnotations;

namespace API_EF_Hash_Token.API.Forms
{
    public class SizeStockForm
    {
        [Required]
        public int SizeId { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
