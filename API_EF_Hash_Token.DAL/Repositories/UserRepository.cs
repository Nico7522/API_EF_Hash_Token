using API_EF_Hash_Token.DAL.Domain;
using API_EF_Hash_Token.DAL.Entities;
using API_EF_Hash_Token.DAL.Interfaces;
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

        public Task<UserEntity> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public Task<UserEntity?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity?> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity?> Register()
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Update(UserEntity entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
