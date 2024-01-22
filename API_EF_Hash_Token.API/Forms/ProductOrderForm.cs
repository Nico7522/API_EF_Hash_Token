using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_EF_Hash_Token.API.Forms
{
    public class ProductOrderForm
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(0, 999999999.99)]
        [DefaultValue("0")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Range(0, 1)]
        [DefaultValue("0")]
        public decimal Discount { get; set; }
    }
}
