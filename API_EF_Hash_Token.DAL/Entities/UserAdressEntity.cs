using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Entities
{
    public class UserAdressEntity
    {
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int AdressId { get; set; }
        public AdressEntity Adress { get; set; }
    }
}
