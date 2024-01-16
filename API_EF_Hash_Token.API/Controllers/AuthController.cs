using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.API.Infrastructure;
using API_EF_Hash_Token.API.Mappers;
using API_EF_Hash_Token.BLL.IInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_EF_Hash_Token.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly TokenManager _tokenManager;

        public AuthController(IAuthService authService, TokenManager tokenManager)
        {
            _authService = authService;
            _tokenManager = tokenManager;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO?>> Register([FromBody] RegisterUserForm form)
        {
           UserDTO? user = await _authService.Register(form.ToUserModel()).ContinueWith(r => r.Result?.ToUserDTO());

            if(user is null)
                return BadRequest();

            string token = _tokenManager.GerenateJwt(user);

            return Ok(new { Token = token});


        }
    }
}
