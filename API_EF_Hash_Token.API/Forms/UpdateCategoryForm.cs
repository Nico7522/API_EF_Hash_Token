using System.ComponentModel.DataAnnotations;

namespace API_EF_Hash_Token.API.Forms
{
    public class UpdateCategoryForm
    {
        [Required]
        [MaxLength(150)]

        public string CategoryName { get; set; }

        [Required]
        [MaxLength(500)]

        public string Description { get; set; }
    }
}
