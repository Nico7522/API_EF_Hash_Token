using System.ComponentModel.DataAnnotations;

namespace API_EF_Hash_Token.API.Forms
{
    public class UpdateStockForm
    {
        [Required]
        public int Stock { get; set; }
    }
}
