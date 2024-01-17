using System.ComponentModel.DataAnnotations;

namespace API_EF_Hash_Token.API.Forms
{
    public class UpdateAdressForm
    {
        [Required]
        public int Number { get; set; }

        [Required]
        [MaxLength(200)]
        public string CityName { get; set; }

        [Required]
        [MaxLength(350)]
        public string Street { get; set; }

        [Required]
        [MaxLength(350)]
        public string Country { get; set; }
    }
}
