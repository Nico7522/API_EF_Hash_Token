using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.Test.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public List<OrderProduct> Products;

        public Order()
        {
            Products = new List<OrderProduct>();
        }
    }
}
