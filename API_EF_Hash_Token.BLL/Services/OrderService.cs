using API_EF_Hash_Token.BLL.IInterfaces;
using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<IEnumerable<OrderProductModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
