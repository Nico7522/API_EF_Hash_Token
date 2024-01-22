using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.BLL.Models;

namespace API_EF_Hash_Token.API.Mappers
{
    internal static class OrderMappers
    {
        internal static OrderModel ToOrderModel(this CreateOrderForm form)
        {
            return new OrderModel()
            {
                UserId = form.UserId,
                OrderProducts = form.OrderProduct.Select(p => p.ToOrderProductModel()).ToList() ?? new List<OrderProductModel>()
            };
        }

        internal static OrderProductModel ToOrderProductModel(this ProductOrderForm form)
        {
            return new OrderProductModel() {
            
                ProductId = form.ProductId,
                Price = form.Price,
                Quantity = form.Quantity
            };
        }
    }
  

}
