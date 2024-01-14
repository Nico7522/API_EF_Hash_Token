using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Entities
{
    public class ProductOrderEntity
    {
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal ReductionPerProduct { get; set; }

    }
}
