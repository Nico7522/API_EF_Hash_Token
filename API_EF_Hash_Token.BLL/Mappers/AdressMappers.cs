using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Mappers
{
    internal static class AdressMappers
    {
        internal static AdressModel ToAdressModel(this AdressEntity entity)
        {
            return new AdressModel()
            {
                AdressId = entity.AdressId,
                CityName = entity.CityName,
                Country = entity.Country,
                Number = entity.Number,
                Street = entity.Street,
            };
        }

        internal static AdressEntity ToAdressEntity(this AdressModel model)
        {
            return new AdressEntity()
            {
                CityName = model.CityName,
                Country = model.Country,
                Number = model.Number,
                Street = model.Street,
            };
        }

   
    }
}
