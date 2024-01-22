using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.API.Mappers;
using API_EF_Hash_Token.BLL.IInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_EF_Hash_Token.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAll()
        {
            return await _orderService.GetAll().ContinueWith(r => r.Result.Select(o => o.ToOrderDTO()).ToList());
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponseDTO?>> Insert(CreateOrderForm form)
        {
            OrderResponseDTO? insertedOrder = await _orderService.Insert(form.ToOrderModel()).ContinueWith(r => r.Result.ToOrderResponseDTO());
            return insertedOrder is not null ? Ok(insertedOrder) : BadRequest(); 
        }
    }
}
