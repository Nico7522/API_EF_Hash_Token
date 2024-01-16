using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.BLL.Models;

namespace API_EF_Hash_Token.API.Mappers
{
    internal static class UserMappers
    {

        internal static UserDTO ToUserDTO(this UserModel model)
        {
            return new UserDTO() {
                UserId = model.UserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,

            };
        }
    }
}
