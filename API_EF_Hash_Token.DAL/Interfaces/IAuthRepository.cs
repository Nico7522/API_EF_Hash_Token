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
        Task<UserEntity?> Register(UserEntity user);
        Task<UserEntity?> Login(string email, string password);
        Task<bool> UpdateEmail(string email, int id);

        Task<bool> UpdatePassword(UserEntity userToUpdate, string newPassword);

        Task<bool> RequestResetPassword(string email);
    }
}
