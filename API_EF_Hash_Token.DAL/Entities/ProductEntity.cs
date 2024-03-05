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
        public List<ProductOrderEntity> Orders { get; set; } = new List<ProductOrderEntity>();
        public List<ProductCategoryEntity> Categories { get; set; }  = new List<ProductCategoryEntity>();
        public List<CategoryEntity> CategoriesEntity { get; set; } = new List<CategoryEntity>();
        public List<SizeProductEntity> Sizes { get; set; } = new List<SizeProductEntity>();
        public List<int> CategoriesId { get; set; } = new List<int>();
        public List<SizeStock> SizeStock { get; set; } = new List<SizeStock>();
    }
}
