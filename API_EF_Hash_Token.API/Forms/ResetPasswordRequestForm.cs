using System.ComponentModel.DataAnnotations;

namespace API_EF_Hash_Token.API.Forms
{
    public class ResetPasswordRequestForm
    {
        [Required]
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Email { get; set; }
    }
}
