using API_EF_Hash_Token.DAL.Domain;
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

        public async Task<UserEntity> Delete(UserEntity user)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserEntity?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<UserEntity?> Login(string email, string password)
        {

            // Peut-être à mettre dans la BLL
            UserEntity? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email); 
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

        public async Task<UserEntity> Update(UserEntity entity, int id)
        {
            UserEntity? user = await GetById(6);
            user = entity;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
