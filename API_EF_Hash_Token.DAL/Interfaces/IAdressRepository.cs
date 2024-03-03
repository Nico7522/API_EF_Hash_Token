using API_EF_Hash_Token.DAL.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Interfaces
{
    public interface IAdressRepository : ICrudRepository<int, AdressEntity>
    {
        Task<bool> CheckIfExist(AdressEntity entityToFind);
        Task<AdressEntity?> AddUserAdress(AdressEntity adress, UserEntity user);
    }
}
