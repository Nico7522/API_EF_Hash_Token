using API_EF_Hash_Token.BLL.IInterfaces;
using API_EF_Hash_Token.BLL.Mappers;
using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<UserModel?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await _userRepository.GetAll().ContinueWith(u => u.Result.Select(u => u.ToUserModel()));
        }

        public async Task<UserModel?> GetByEmail(string email)
        {
            return await _userRepository.GetByEmail(email).ContinueWith(r => r.Result?.ToUserModel());
        }

        public async Task<UserModel?> GetById(int id)
        {
            UserModel? user = await _userRepository.GetById(id).ContinueWith(r => r.Result?.ToUserModel());
            if (user is null)
                return null;

            return user;
        }

        public async Task<UserModel?> Update(UserModel newUser, int id)
        {
           UserModel? userToUpdate = await GetById(id);

            if (userToUpdate is null)
                return null;

            UserModel updatedUser = await _userRepository.Update(newUser.ToUserEntity(), id).ContinueWith(r => r.Result.ToUserModel());
            return updatedUser;
        }
    }
}
