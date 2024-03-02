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
        Task<IEnumerable<ProductEntity>> GetByCategory(string categories);
        Task<IEnumerable<ProductEntity>> GetByBrand(string brands);
        Task<IEnumerable<ProductEntity>> GetByPrice(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<ProductEntity>> GetByTopSales();
        Task<bool> UpdateCategory(ProductEntity product, int[]categoriesId);
        Task<bool> UpdateStock(int sizeId, int productId, int stock);
        Task<bool> UpdatePicture(ProductEntity product, string imgUrl);
        Task<bool> SaveChange();
        IEnumerable<ProductEntity> Filter(FilterEntity filter);
        Task<bool> RemoveCategoryFromProduct(ProductEntity product, CategoryEntity category);



    }
}
