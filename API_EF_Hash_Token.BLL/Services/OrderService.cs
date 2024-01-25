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
        private readonly IProductRepository _productRepository;
        private readonly ISizeRepository _sizeRepository;

        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository, IProductRepository productRepository, ISizeRepository sizeRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;
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
            // Check si l'utilisateur existe
            UserEntity? userFound = await _userRepository.GetById(orderModel.UserId);
            if (userFound is null) return null;

            // Déclaration d'une variable pour le prix total de la commande
            decimal tp = 0;

            foreach (var product in orderModel.OrderProducts)
            {
                // Check si le produit existe.
                ProductEntity? productFound = await _productRepository.GetById(product.ProductId);
                if (productFound is null) return null;

                // Check si la taille existe
                SizeEntity? sizeFound = await _sizeRepository.GetById(product.SizeId);
                if(sizeFound is null) return null;

                // Pour chaque produit, on applique les réductions si il y en a, et on multiplie par la quantité acheté. Pour avoir le prix à l'unité * la quantité.
                product.Price = (product.Price - (product.Price*product.ReductionPerProduct)) * product.Quantity;
                // on augmente le prix total de la commande par le prix à l'unité * la quantité du produit.
                tp += product.Price;
            }
            // On applique les réductions sur le prix total si il y en a.
            orderModel.TotalPrice = tp - (tp*orderModel.TotalReduction);

            // On set la date de la commande
            orderModel.OrderDate = DateTime.Now;

            OrderModel? insertedOrder = await _orderRepository.Insert(orderModel.ToOrderEntity()).ContinueWith(r => r.Result?.ToOrderModel());
            return insertedOrder;
        }
    }
}
