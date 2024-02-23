using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.API.Mappers;
using API_EF_Hash_Token.BLL.IInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>?> GetByUserId(int userId)
        {
            IEnumerable<OrderDTO>? userOrders = await _orderService.GetByUserId(userId).ContinueWith(r => r.Result?.Select(o => o.ToOrderDTO()));
            return userOrders is not null ? Ok(userOrders) : BadRequest();
        }

        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetByUserEmail(SearchByEmailForm form)
        {
            IEnumerable<OrderDTO>? userOrders = await _orderService.GetByUserEmail(form.Email).ContinueWith(r => r.Result?.Select(o => o.ToOrderDTO()));
            return userOrders is not null ? Ok(userOrders) : NotFound(); 
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<OrderResponseDTO?>> Insert(CreateOrderForm form)
        {
            // Récupérer l'id dans les claims
            //var identity = HttpContext.User.Identity as ClaimsIdentity;
            //if (identity != null)
            //{
            //    IEnumerable<Claim> claims = identity.Claims;
            //    // or
            //    string? id = identity.FindFirst(ClaimTypes.Sid)?.Value;

            //    if(id is not null) 
            //        await Console.Out.WriteLineAsync(id.ToString());

            //}


            OrderResponseDTO? insertedOrder = await _orderService.Insert(form.ToOrderModel()).ContinueWith(r => r.Result?.ToOrderResponseDTO());
            return insertedOrder is not null ? Ok(insertedOrder) : NotFound(); 
        }

    }
}
