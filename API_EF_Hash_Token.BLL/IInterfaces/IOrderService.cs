using API_EF_Hash_Token.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.IInterfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> GetAll();
        Task<IEnumerable<OrderModel>> GetByUserId(int UserId);
        Task<IEnumerable<OrderModel>> GetByUserEmail(string email);
        Task<OrderModel?> Insert(OrderModel orderModel);
    }
}
