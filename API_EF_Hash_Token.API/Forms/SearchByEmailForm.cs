using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_EF_Hash_Token.API.Forms
{
    public class SearchByEmailForm
    {
        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        [DefaultValue("exemple@gmail.com")]
        public string Email { get; set; }
    }
}
