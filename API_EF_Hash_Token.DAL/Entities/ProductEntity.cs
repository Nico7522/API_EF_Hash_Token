using API_EF_Hash_Token.DAL.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Entities
{
    public class ProductEntity
    {
        public int PrdoductId { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Sexe { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public List<ProductOrderEntity> Orders { get; set; }
        public List<ProductCategoryEntity> Categories { get; set; }
        public List<CategoryEntity> CategoriesEntity { get; set; }
        public List<SizeProductEntity> Sizes { get; set; }
        public List<int> CategoriesId { get; set; }
        public List<SizeStock> SizeStock { get; set; }
    }
}
