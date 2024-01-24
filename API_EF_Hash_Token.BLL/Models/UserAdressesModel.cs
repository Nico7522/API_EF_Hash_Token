using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Models
{
    public class UserAdressesModel
    {
        // TODO : faire des constructeurs
        public UserModel user { get; set; }
        public List<AdressModel>? Adresses { get; set; }
    }
}
