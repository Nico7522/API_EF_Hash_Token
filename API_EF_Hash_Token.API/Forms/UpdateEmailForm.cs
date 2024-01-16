using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace API_EF_Hash_Token.API.Forms
{
    public class UpdateEmailForm
    {
        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        [DefaultValue("exemple@gmail.com")]
        public string Email { get; set; }
    }
}
