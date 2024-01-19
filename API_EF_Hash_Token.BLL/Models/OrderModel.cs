using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Models
{
    public class OrderModel
    {
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public List<OrderProductModel> OrderProducts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
