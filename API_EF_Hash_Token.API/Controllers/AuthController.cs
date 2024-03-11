using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.API.Infrastructure;
using API_EF_Hash_Token.API.Mappers;
using API_EF_Hash_Token.BLL.IInterfaces;
using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.BLL.Services;
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

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO?>> Register([FromBody] RegisterUserForm form)
        {
            UserDTO? user = await _authService.Register(form.ToUserModel()).ContinueWith(r => r.Result?.ToUserDTO());

            if (user is null)
                return BadRequest();

            string token = _tokenManager.GerenateJwt(user);

            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserForm form)
        {
            UserDTO? user = await _authService.Login(form.Email, form.Password).ContinueWith(r => r.Result?.ToUserDTO());

            if (user is null) return BadRequest();

            string token = _tokenManager.GerenateJwt(user);
            return Ok(new { Token = token });
        }

        [HttpPatch("{id}/update/email")]
        public async Task<ActionResult<bool>> UpdateEmail(UpdateEmailForm form, int id)
        {
            bool isUpdated = await _authService.UpdateEmail(form.Email, id);
            return isUpdated ? Ok("Email modifiée avec succèss") : BadRequest();
        }

        [HttpPost("reset/password")]
        public async Task<ActionResult<bool>> RequestResetPassword(ResetPasswordRequestForm form)
        {
            bool isEmailSend = await _authService.RequestResetPassword(form.Email);
            return isEmailSend ? Ok(isEmailSend) : BadRequest();
        }

        [HttpPatch("{id:int}/update/password")]
        public async Task<ActionResult> UpdatePassword(UpdatePasswordForm form, int id)
        {
            bool isUpdated = await _authService.UpdatePassword(form.Password, id);
            return isUpdated ? Ok(isUpdated) : BadRequest();
        }
    }
}
