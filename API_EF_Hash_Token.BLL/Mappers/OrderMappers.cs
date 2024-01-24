using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Mappers
{
    internal static class OrderMappers
    {
        internal static OrderModel ToOrderModel(this OrderEntity entity)
        {
            return new OrderModel(entity.OrderId, entity.UserId, entity.User.ToUserModel(), entity.Products.Select(p => p.Product.ToOrderProductModel(p.Quantity, p.Price, p.ReductionPerProduct)).ToList(), entity.TotalPrice, entity.OrderDate, entity.TotalReduction);
            //{
            //    OrderId = entity.OrderId,
            //    UserId = entity.UserId,
            //    User = entity.User.ToUserModel(),
            //    TotalPrice = entity.TotalPrice,
            //    OrderDate = entity.OrderDate,
            //    TotalReduction = entity.TotalReduction,
            //    OrderProducts = entity.Products.Select(p => p.Product.ToOrderProductModel(p.Quantity, p.Price, p.ReductionPerProduct)).ToList(),
                

            //};
        }
        internal static OrderProductModel ToOrderProductModel(this ProductEntity entity, int quantity, decimal price, decimal reductionPerProduct)
        {
            return new OrderProductModel()
            {
                ProductId = entity.PrdoductId,
                ModelName = entity.ModelName,
                Quantity = quantity,
                ReductionPerProduct = reductionPerProduct,
                Price = price,

            };
        }

        internal static OrderEntity ToOrderEntity(this OrderModel model) {

            return new OrderEntity() {
                UserId = model.UserId,
                TotalPrice = model.TotalPrice,
                OrderDate = model.OrderDate,
                TotalReduction = model.TotalReduction,
                Products = model.OrderProducts.Select(p => p.ToProductOrderEntity()).ToList()
                
            };
        }

        internal static ProductOrderEntity ToProductOrderEntity(this OrderProductModel model)
        {
            return new ProductOrderEntity()
            {
                ProductId = model.ProductId,
                Price = model.Price,
                Quantity = model.Quantity,
                ReductionPerProduct = model.ReductionPerProduct,
                SizeId = model.SizeId,
            };
        }
    }
}
