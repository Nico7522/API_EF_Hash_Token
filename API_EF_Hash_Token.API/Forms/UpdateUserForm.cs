using API_EF_Hash_Token.API.CustomAttributes;
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
        [CheckMaxLength]
        public int PhoneNumber { get; set; }
    }
}
