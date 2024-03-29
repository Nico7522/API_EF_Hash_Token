﻿using API_EF_Hash_Token.BLL.IInterfaces;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserModel?> Delete(int id)
        {
            UserEntity? entityToDelete = await _userRepository.GetById(id);
            if (entityToDelete is null) return null;

            UserModel? deletedUser = await _userRepository.Delete(entityToDelete).ContinueWith(r => r.Result?.ToUserModel());
            return deletedUser;
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

            UserEntity? entityToUpdate = await _userRepository.GetById(id);
            if (entityToUpdate is null) return null;
       
            UserModel? updatedUser = await _userRepository.Update(entityToUpdate, newUser.ToUserEntity()).ContinueWith(r => r.Result?.ToUserModel());
            return updatedUser;
        }

        public async Task<IEnumerable<UserAdressesModel>> GetAllWithAdresses()
        {
            IEnumerable<UserAdressesModel> result = await _userRepository.GetAllWithAdresses().ContinueWith(u => u.Result.Select(r => r.ToUserAdresses()));
            return result;
        }

        public async Task<bool> ActiveAccount(int userId)
        {
            UserEntity? userAccountToActive = await _userRepository.GetById(userId);
            if (userAccountToActive is null) return false;


            bool isActivate = await _userRepository.ActiveAccount(userAccountToActive);
            return isActivate;
        }
    }
}
