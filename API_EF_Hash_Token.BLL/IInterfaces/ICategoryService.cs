using API_EF_Hash_Token.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.IInterfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetAll();
        Task<CategoryModel?> GetById(int id);
        Task<CategoryModel?> Insert(CategoryModel categoryModel);
        Task<CategoryModel?> Update(CategoryModel modifiedCategory, int id);
        Task<CategoryModel?> Delete(int id);


    }
}
