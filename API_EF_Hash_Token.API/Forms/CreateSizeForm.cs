using System.ComponentModel.DataAnnotations;

namespace API_EF_Hash_Token.API.Forms
{
    public class CreateSizeForm
    {
        [Required]
        public int Size { get; set; }
    }
}
