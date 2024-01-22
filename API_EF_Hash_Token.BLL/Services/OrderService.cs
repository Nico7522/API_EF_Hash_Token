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
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<OrderModel>> GetAll()
        {
           return await _orderRepository.GetAll().ContinueWith(r => r.Result.Select(o => o.ToOrderModel()));
        }

        public async Task<IEnumerable<OrderModel>?> GetByUserEmail(string email)
        {
            UserEntity? userFound = await _userRepository.GetByEmail(email);
            if (userFound is null) return null;
            return await _orderRepository.GetByUserEmail(email).ContinueWith(r => r.Result?.Select(o => o.ToOrderModel()));

        }

        public async Task<IEnumerable<OrderModel>?> GetByUserId(int userId)
        {
            UserEntity? userFound = await _userRepository.GetById(userId);
            if (userFound is null) return null;
            return await _orderRepository.GetByUserId(userId).ContinueWith(r => r.Result?.Select(o => o.ToOrderModel()));
        }

        public async Task<OrderModel?> Insert(OrderModel orderModel)
        {
            decimal tp = 0;
            foreach (var product in orderModel.OrderProducts)
            {
                product.Price = (product.Price - (product.Price*product.ReductionPerProduct)) * product.Quantity;
                tp += product.Price;
            }
            orderModel.TotalPrice = tp - (tp*orderModel.TotalReduction);
            orderModel.OrderDate = DateTime.Now;
            OrderModel? insertedOrder = await _orderRepository.Insert(orderModel.ToOrderEntity()).ContinueWith(r => r.Result?.ToOrderModel());
            return insertedOrder;
        }
    }
}
