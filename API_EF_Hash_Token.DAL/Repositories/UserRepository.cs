using API_EF_Hash_Token.DAL.Entities;
using API_EF_Hash_Token.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _pepper;
        private readonly int _iteration = 3;

        public UserRepository()
        {
            _pepper = Environment.GetEnvironmentVariable("pepper");
        }


        public IEnumerable<UserEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserEntity Login(string email, string password)
        {
            return new UserEntity();
        }

        public void Register()
        {
            
        }
    }
}
