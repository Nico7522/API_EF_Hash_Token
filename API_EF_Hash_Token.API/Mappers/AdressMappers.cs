using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.BLL.Models;

namespace API_EF_Hash_Token.API.Mappers
{
    internal static class AdressMappers
    {
        internal static AdressDTO ToAdressDTO(this AdressModel model)
        {
            return new AdressDTO() { 
            
                AdressId = model.AdressId,
                CityName = model.CityName,
                Number = model.Number,
                Country = model.Country,
                Street = model.Street,
            };
        }
    }
}
