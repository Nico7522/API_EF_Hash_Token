using API_EF_Hash_Token.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.IInterfaces
{
    public interface IAuthService
    {
        Task<UserModel> Register(UserModel user);
        Task<UserModel> Login(string username, string password);
        Task<bool> UpdateEmail(string email, int id);
        //Task<bool> UpdatePassword(string password, int id);


    }
}
