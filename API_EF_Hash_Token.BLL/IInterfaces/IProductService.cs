using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.BLL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.IInterfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAll();

        Task<IEnumerable<ProductModel>?> GetByCategory(int categoryId);
        Task<ProductModel> GetById(int id);

        Task<IEnumerable<ProductModel>> GetByStep(int offset);

        Task<ProductModel?> Insert(ProductModel model, List<int> categoriesId, List<SizeModel> sizeStock);
        Task<ProductModel?> Update(ProductModel modifiedProduct, int id);
        Task<ProductModel?> Delete(int id);
        Task<bool> UpdateStock(int sizeId, int productId, int stock);
        Task<IEnumerable<ProductModel>> GetByTopSales();
        Task<bool> UpdatePicture(int id, string imageUrl);
        Task<bool> SaveChange();
    }
}
