using System.ComponentModel.DataAnnotations;

namespace API_EF_Hash_Token.API.Forms
{
    public class AddCategoryToProductForm
    {
        [Required]
        public List<int> CategoryId { get; set; } = new List<int>();
    }
}
