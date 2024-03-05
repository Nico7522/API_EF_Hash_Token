using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Entities
{
    public class AdressEntity
    {
        public int AdressId { get; set; }
        public int Number { get; set; }
        public string CityName { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public List<UserEntity> UsersList { get; set; } = new List<UserEntity>();
        public List<UserAdressEntity> Users { get; set; }

    }
}
