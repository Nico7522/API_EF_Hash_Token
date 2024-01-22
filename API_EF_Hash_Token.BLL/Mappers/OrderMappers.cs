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
            return new OrderModel() 
            {
                UserId = entity.UserId,
                User = entity.User.ToUserModel(),
                TotalPrice = entity.TotalPrice,
                Reduction = entity.TotalReduction,

                // Faire un mapper qui map un ProductEntity vers un OrderProductModel et passer en paramètres la quantité ...
                OrderProducts = entity.Products.Select(p => p.Product.ToOrderProductModel(p.Quantity, p.Price)).ToList()
            };
        }
        internal static OrderProductModel ToOrderProductModel(this ProductEntity entity, int quantity, decimal price)
        {
            return new OrderProductModel()
            {
                ProductId = entity.PrdoductId,
                ModelName = entity.ModelName,
                Quantity = quantity,
                Price = price,
                //ReductionPerProduct = entity.Discount*quantity,

            };
        }

        internal static OrderEntity ToOrderEntity(this OrderModel model) {

            return new OrderEntity() {
                UserId = model.UserId,
                // À faire dans la BLL
                OrderDate = DateTime.Now,
                TotalPrice = model.TotalPrice,
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
            };
        }
    }
}
