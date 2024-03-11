using API_EF_Hash_Token.BLL.IInterfaces;
using API_EF_Hash_Token.BLL.Mappers;
using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Entities;
using API_EF_Hash_Token.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;

        public AuthService(IAuthRepository authRepository, IUserRepository userRepository)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
        }

        public async Task<UserModel> Login(string email, string password)
        {
            UserModel? logedUser = await _authRepository.Login(email, password).ContinueWith(r => r.Result?.ToUserModel());

            if (logedUser is null)
                return null;

            return logedUser;
                
            
        }

        public async Task<UserModel> Register(UserModel user)
        {
            UserModel? existingUser = await _userRepository.GetByEmail(user.Email).ContinueWith(r => r.Result?.ToUserModel());
            if (existingUser is not null)
                return null;

            UserModel? newUser = await _authRepository.Register(user.ToUserEntity()).ContinueWith(r => r.Result?.ToUserModel());
            if (newUser is null)
                return null;

            return newUser;
        }

        public async Task<bool> RequestResetPassword(string email)
        {
            UserEntity? user = await _userRepository.GetByEmail(email);
            if (user is null) return false;
            bool isEmailSend = await _userRepository.RequestResetPassword(email);
            return isEmailSend;
        }

        public async Task<bool> UpdateEmail(string email, int id)
        {
            bool isUpdated = await _authRepository.UpdateEmail(email, id);
            return isUpdated;
        }

        public async Task<bool> UpdatePassword(string password, int id)
        {
            UserEntity? user = await _userRepository.GetById(id);
            if (user is null) return false;


            bool isUpdated = await _authRepository.UpdatePassword(user, password);

            return isUpdated;
        }
    }
}
