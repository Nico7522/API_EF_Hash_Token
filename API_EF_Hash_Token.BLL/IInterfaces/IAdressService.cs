using API_EF_Hash_Token.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.IInterfaces
{
    public interface IAdressService
    {
        Task<IEnumerable<AdressModel>> GetAll();
        Task<AdressModel?> GetById(int id);
        Task<AdressModel?> Insert(AdressModel adressModel);
        Task<AdressModel?> Update(AdressModel modifiedAdress, int id);
        Task<AdressModel?> Delete(int id);
        Task<bool> AddUserAdress(AdressModel adress, int userId);
    }
}
