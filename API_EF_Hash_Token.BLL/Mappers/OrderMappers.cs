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
        internal static OrderModel ToOrderProductModel(this OrderEntity entity)
        {
            return new OrderModel() 
            {
                UserId = entity.UserId,
                User = entity.User.ToUserModel(),
                // Faire un mapper qui map un ProductEntity vers un OrderProductModel et passer en paramètres la quantité ...
                //OrderProducts = entity.Products.Select(p => p.Product.)
            };
        }
    }
}
