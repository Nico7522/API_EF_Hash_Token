using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace API_EF_Hash_Token.API.Forms
{
    public class UpdateProductForm
    {
        [Required]
        [MaxLength(150)]
        public string ModelName { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(150)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(5)]
        public string Sexe { get; set; }

        [Required]
        [Range(0, 999999999.99)]
        [DefaultValue("0")]
        public decimal Price { get; set; }

        [Range(0, 1)]
        [DefaultValue("0")]
        public decimal Discount { get; set; }
    }
}
