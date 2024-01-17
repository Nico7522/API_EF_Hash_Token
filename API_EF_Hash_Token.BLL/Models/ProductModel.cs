using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Models
{
    public class ProductModel
    {
        public int PrdoductId { get; init; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Sexe { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public List<CategoryModel> Categories { get; set; } = null;

        public ProductModel(string modelName, string description, string brand, string sexe, decimal price, decimal discount, List<CategoryModel> categories)
        {
            this.ModelName = modelName;
            this.Description = description;
            this.Brand = brand;
            this.Sexe = sexe;
            this.Price = price;
            this.Discount = discount;
            Categories = categories;

        }

        public ProductModel(string modelName, string description, string brand, string sexe, decimal price, decimal discount, List<CategoryModel> categories, int productId) : this(modelName, description, brand, sexe, price,  discount, categories)
        {
            this.PrdoductId = productId;
        }
    }
}
