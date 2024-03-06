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
        Task<ProductEntity?> AddCategoryToProduct(ProductEntity product, List<CategoryEntity> categories);
        Task<ProductEntity?> UpdateStock(SizeEntity sizeId, ProductEntity product, int stock);
        string? UpdatePicture(ProductEntity product, string imgUrl);
        Task<bool> SaveChange();
        IEnumerable<ProductEntity> Filter(FilterEntity filter);
        Task<bool> RemoveCategoryFromProduct(ProductEntity product, CategoryEntity category);
        Task<ProductEntity?> AddSizeToProduct(ProductEntity product, SizeEntity sizeToAdd, int stock);
        Task<bool> RemoveSizeFromProduct(ProductEntity product, SizeEntity sizeToRemove);


    }
}
