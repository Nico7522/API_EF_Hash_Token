﻿using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Mappers
{
    internal static class UserMappers
    {
        internal static UserModel ToUserModel(this UserEntity entity)
        {
            return new UserModel(entity.UserId, entity.LastName, entity.FirstName, entity.Email, entity.PhoneNumber, entity.Role, entity.IsActive, entity.Addresses?.Where(a => a.Adress != null).Select(a => a.Adress.ToAdressModel()).ToList());
        }

        internal static UserEntity ToUserEntity(this UserModel model)
        {
            return new UserEntity() { 
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Password = model.Password,
            };
        }

        internal static UserAdressesModel ToUserAdresses(this UserEntity entity)
        {
            return new UserAdressesModel()
            {

                user = entity.ToUserModel(),
                Adresses = entity.Addresses != null
            ? entity.Addresses.Where(ua => ua.Adress is not null)
                .Select(ua => ua.Adress.ToAdressModel()).ToList()
            : new List<AdressModel>()

            };
        }
    }
}
