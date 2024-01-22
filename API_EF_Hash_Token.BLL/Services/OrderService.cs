using API_EF_Hash_Token.BLL.IInterfaces;
using API_EF_Hash_Token.BLL.Mappers;
using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Entities;
using API_EF_Hash_Token.DAL.Interfaces;
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
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderModel>> GetAll()
        {
           return await _orderRepository.GetAll().ContinueWith(r => r.Result.Select(o => o.ToOrderModel()));
        }

        public async Task<IEnumerable<OrderModel>> GetByUserEmail(string email)
        {
            return await _orderRepository.GetByUserEmail(email).ContinueWith(r => r.Result.Select(o => o.ToOrderModel()));

        }

        public async Task<IEnumerable<OrderModel>> GetByUserId(int UserId)
        {
            return await _orderRepository.GetByUserId(UserId).ContinueWith(r => r.Result.Select(o => o.ToOrderModel()));
        }

        public async Task<OrderModel> Insert(OrderModel orderModel)
        {
            decimal tp = 0;
            foreach (var product in orderModel.OrderProducts)
            {
                tp += product.Price*product.Quantity;
            }
            orderModel.TotalPrice = tp;
            await _orderRepository.Insert(orderModel.ToOrderEntity());
            return orderModel;
        }
    }
}
