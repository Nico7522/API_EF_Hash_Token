using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.BLL.Models;

namespace API_EF_Hash_Token.API.Mappers
{
    internal static class UserMappers
    {

        internal static UserDTO ToUserDTO(this UserModel model)
        {
            return new UserDTO(model.UserId, model.FirstName, model.LastName, model.Email, model.PhoneNumber);
        
        }

        internal static UserModel ToUserModel(this UpdateUserForm form)
        {
            return new UserModel(form.LastName, form.FirstName, form.PhoneNumber);
        }

        internal static UserModel ToUserModel(this RegisterUserForm form)
        {
            return new UserModel(form.FirstName, form.LastName, form.Email, form.PhoneNumber, form.Password);
        }
    }
}
