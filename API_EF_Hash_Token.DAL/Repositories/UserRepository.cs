﻿using API_EF_Hash_Token.DAL.Domain;
using API_EF_Hash_Token.DAL.Entities;
using API_EF_Hash_Token.DAL.Interfaces;
using API_EF_Hash_Token.DAL.Methods;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly string _pepper;
        private readonly int _iteration = 3;
        private IConfiguration _configuration;

        public UserRepository(DataContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
            _pepper = _configuration.GetSection("secret").Value;
        }

        public async Task<UserEntity?> Delete(int id)
        {
            UserEntity? userToDelete = await GetById(id);
            if (userToDelete is null)
                return null;

            _context.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return userToDelete;
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserEntity?> GetByEmail(string email)
        {
            UserEntity? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;

        }

        public async Task<UserEntity?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<UserEntity?> Login(string email, string password)
        {

            UserEntity? user = await GetByEmail(email);
            if (user is null)
                return null;

            string passwordHash = PasswordHasher.ComputeHash(password, user.PasswordSalt, _pepper, _iteration);
            if (user.PasswordHash != passwordHash)
                return null;

            return user;
        }

        public async Task<UserEntity?> Register(UserEntity user)
        {
            user.PasswordSalt = PasswordHasher.GenerateSalt();
            user.PasswordHash = PasswordHasher.ComputeHash(user.Password, user.PasswordSalt, _pepper, _iteration);
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserEntity?> Update(UserEntity newEntity, int id)
        {
            // PB : obligé de faire la recherche par id ici
            UserEntity? user = await _context.Users.FindAsync(id);

            if (user is null) return null;

            user.FirstName = newEntity.FirstName;
            user.LastName = newEntity.LastName;
            user.PhoneNumber = newEntity.PhoneNumber;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateEmail(string email, int id)
        {
            UserEntity? user = await GetById(id);
            if (user is null)
                return false;

            user.Email = email;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePassword(string newPassword, int id)
        {
            UserEntity? user = await GetById(id);

            if (user is null) return false;

            user.PasswordSalt = PasswordHasher.GenerateSalt();
            user.PasswordHash = PasswordHasher.ComputeHash(newPassword, user.PasswordSalt, _pepper, _iteration);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UserEntity>> GetAllWithAdresses()
        {
            return await _context.Users
              .Include(u => u.Addresses)
                  .ThenInclude(a => a.Adress)
              .ToListAsync();


        }
    }
}
