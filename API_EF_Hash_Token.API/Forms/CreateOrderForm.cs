using API_EF_Hash_Token.BLL.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_EF_Hash_Token.API.Forms
{
    public class CreateOrderForm
    {
        [Required]
        public int UserId { get; set; }

        [Range(0, 1)]
        [DefaultValue("0")]
        public decimal TotalReduction { get; set; }

        [Required]
        public List<ProductOrderForm> OrderProduct { get; set; } = new List<ProductOrderForm>();
    }
}
