using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Entities
{
    public class OrderEntity
    {
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalReduction { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public List<ProductOrderEntity> Products { get; set; }

    }
}
