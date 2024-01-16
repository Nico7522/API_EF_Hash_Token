using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_EF_Hash_Token.API.Forms
{
    public class UpdateUserForm
    {
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }


        [Required]
        [MinLength(7)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{7,}$")]
        [DefaultValue("password")]
        public int PhoneNumber { get; set; }
    }
}
