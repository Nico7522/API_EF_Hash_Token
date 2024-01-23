using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; init; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public CategoryModel(string categoryName, string description)
        {
            this.CategoryName = categoryName;
            this.Description = description;
        }

        internal CategoryModel(int categoryId, string categoryName, string descriptio) : this(categoryName, descriptio)
        {
            this.CategoryId = categoryId;
        }
    }
}
