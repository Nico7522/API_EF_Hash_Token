using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Models
{
    public class OrderProductModel 
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal ReductionPerProduct { get; set; }

        public OrderProductModel(int productId, int sizeId, string modelName, decimal price, int quantity, decimal reductionPerproduct)
        {
            this.ProductId = productId;
            this.SizeId = sizeId;
            this.ModelName = modelName;
            this.Price = price;
            this.Quantity = quantity;
            this.ReductionPerProduct = reductionPerproduct;

        }

        public OrderProductModel(int productId, int sizeId, decimal price, int quantity, decimal reductionPerproduct)
        {
            this.ProductId = productId;
            this.SizeId = sizeId;
            this.Price = price;
            this.Quantity = quantity;
            this.ReductionPerProduct = reductionPerproduct;
        }


    }
}
