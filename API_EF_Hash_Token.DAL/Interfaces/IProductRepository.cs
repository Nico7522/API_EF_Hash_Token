using API_EF_Hash_Token.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Interfaces
{
    public interface IProductRepository : ICrudRepository<int, ProductEntity>
    {
        // Pagination
        Task<IEnumerable<ProductEntity>> GetByStep(int offset);

        Task<IEnumerable<ProductEntity>> GetByCategory(string[] categories);
        Task<bool> UpdateStock(int sizeId, int productId, int stock);

        Task<IEnumerable<ProductEntity>> GetByTopSales();

        Task<bool> UpdatePicture(ProductEntity product, string imgUrl);
        Task<bool> SaveChange();

    }
}
