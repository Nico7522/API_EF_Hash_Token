using API_EF_Hash_Token.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.IInterfaces
{
    public interface ISizeService
    {
        Task<IEnumerable<SizeModel>> GetAll();
        Task<SizeModel?> GetById(int id);
        Task<SizeModel?> Insert(SizeModel model);
        Task<SizeModel?> Update(SizeModel modifiedSize, int id);
        Task<SizeModel?> Delete(int id);



    }
}
