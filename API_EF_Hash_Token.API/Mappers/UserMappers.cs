using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Entities;

namespace API_EF_Hash_Token.API.Mappers
{
    internal static class UserMappers
    {

        internal static UserDTO ToUserDTO(this UserModel model)
        {
            return new UserDTO(model.UserId, model.FirstName, model.LastName, model.Email, model.PhoneNumber, model.Role, model.Adresses?.Select(a => a.ToAdressDTO()).ToList());
        
        }

        internal static UserModel ToUserModel(this UpdateUserForm form)
        {
            return new UserModel(form.LastName, form.FirstName, form.PhoneNumber);
        }

        internal static UserModel ToUserModel(this RegisterUserForm form)
        {
            return new UserModel(form.FirstName, form.LastName, form.Email, form.PhoneNumber, form.Password);
        }

        internal static UserWithAdressesDTO ToUserWithAdressesDTO(this UserAdressesModel model)
        {
            return new UserWithAdressesDTO()
            {
                User = model.user.ToUserDTO(),
                Adresses = model.Adresses.Select(a => a.ToAdressDTO()).ToList(),
            };
        }
    }
}
