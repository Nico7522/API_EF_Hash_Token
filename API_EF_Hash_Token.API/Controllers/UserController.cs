using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.API.Mappers;
using API_EF_Hash_Token.BLL.IInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_EF_Hash_Token.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize("adminPolicy")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
           IEnumerable<UserDTO> users = await _userService.GetAll().ContinueWith(r => r.Result.Select(u => u.ToUserDTO()));

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO?>> GetById(int id)
        {
            UserDTO? user = await _userService.GetById(id).ContinueWith(r => r.Result?.ToUserDTO());
            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPost("email")]
        public async Task<ActionResult<UserDTO?>> GetByEmail(SearchByEmailForm form) {
            
            UserDTO? user = await _userService.GetByEmail(form.Email).ContinueWith(r => r.Result?.ToUserDTO());
            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO?>> Update(UpdateUserForm form, int id)
        {
            UserDTO? updatedUser = await _userService.Update(form.ToUserModel(), id).ContinueWith(r => r.Result?.ToUserDTO());
            return updatedUser is not null ? Ok(updatedUser) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> Delete(int id)
        {
            UserDTO? deletedUser = await _userService.Delete(id).ContinueWith(r => r.Result?.ToUserDTO());
            return deletedUser is not null ? Ok(deletedUser) : NotFound();
        }

        [HttpGet("adresses")]
        public async Task<ActionResult<IEnumerable<UserWithAdressesDTO>>> GetAllWithAdresses()
        {
            IEnumerable<UserWithAdressesDTO> result = await _userService.GetAllWithAdresses().ContinueWith(r => r.Result.Select(all => all.ToUserWithAdressesDTO()));
            return Ok(result);
           
        }
    }
}
