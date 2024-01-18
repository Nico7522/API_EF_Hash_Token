using System.ComponentModel.DataAnnotations;

namespace API_EF_Hash_Token.API.Forms
{
    public class UpdateCategoryForm
    {
        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
