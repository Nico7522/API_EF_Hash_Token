using API_EF_Hash_Token.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Interfaces
{
    public interface IUserRepository : IAuthRepository
    {
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity?> GetById(int id);

        Task<UserEntity?> Update (UserEntity oldEntity, UserEntity newEntity);

        Task<UserEntity?> Delete(UserEntity userToDelete);

        Task<UserEntity?> GetByEmail(string email);

        Task<IEnumerable<UserEntity>> GetAllWithAdresses();
        Task<bool> ActiveAccount(UserEntity user);




    }
}
