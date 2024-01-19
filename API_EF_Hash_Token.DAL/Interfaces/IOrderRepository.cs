using API_EF_Hash_Token.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderEntity>> GetAll();
        Task<IEnumerable<OrderEntity>> GetByUserId(int userId);
        Task<IEnumerable<OrderEntity>> GetByUser(string email);
        Task<OrderEntity?> Insert(OrderEntity entity);
    }
}
