using API_EF_Hash_Token.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.IInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAll();
        Task<UserModel?> GetById(int id);
        Task<UserModel?> GetByEmail(string email);
        Task<UserModel?> Update(UserModel user, int id);
        Task<UserModel?> Delete(int id);
        Task<IEnumerable<UserAdressesModel>> GetAllWithAdresses();

    }
}
