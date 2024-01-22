using API_EF_Hash_Token.API.Dto;
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

        internal static OrderDTO ToOrderDTO(this OrderModel model)
        {
            return new OrderDTO() {
                OrderId = model.OrderId,
                User = model.User.ToUserDTO(),
                TotalPrice = model.TotalPrice,
                OrderDate = model.OrderDate,
                OrderedProducts = model.OrderProducts.Select(po => po.ToProductOrderDTO()).ToList() ?? new List<ProductOrderDTO>()
                
            };
        }


        internal static ProductOrderDTO ToProductOrderDTO(this OrderProductModel model)
        {
            return new ProductOrderDTO() 
            { 
                ProductName = model.ModelName,
                Price = model.Price,
                Quantity = model.Quantity,
            };
        }

        internal static OrderResponseDTO ToOrderResponseDTO(this OrderModel model)
        {
            return new OrderResponseDTO() 
            { 
                OrderId = model.OrderId,
                UserId = model.UserId, 
                TotalPrice = model.TotalPrice, 
                Products = model.OrderProducts.Select(p => p.ToProductOrderResponseDTO()).ToList() ?? new List<ProductOrderResponseDTO>() 
            };
        }

        internal static ProductOrderResponseDTO ToProductOrderResponseDTO(this OrderProductModel model)
        {
            return new ProductOrderResponseDTO() { Price = model.Price, ProductId = model.ProductId, Quantity = model.Quantity };
        }
    }
  

}
