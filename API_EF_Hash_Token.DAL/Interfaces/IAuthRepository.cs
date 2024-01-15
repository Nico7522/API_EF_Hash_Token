using API_EF_Hash_Token.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Interfaces
{
    public interface IAuthRepository
    {
        Task<UserEntity?> Register();
        Task<UserEntity?> Login(string email, string password);
    }
}
