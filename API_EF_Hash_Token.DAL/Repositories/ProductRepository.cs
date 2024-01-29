using API_EF_Hash_Token.DAL.Class;
using API_EF_Hash_Token.DAL.Domain;
using API_EF_Hash_Token.DAL.Entities;
using API_EF_Hash_Token.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
           
        }

        public async Task<ProductEntity?> Delete(ProductEntity entity)
        {
            _dataContext.Products.Remove(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            return await _dataContext.Products.Include(p => p.Categories).ThenInclude(p => p.Category)
                                              .Include(p => p.Sizes).ThenInclude(p => p.Size).ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetByCategory(int categoryId)
        {

            // Fonctionne pas
            return await _dataContext.Products.Where(p => p.Categories.Any(c => c.CategoryId == categoryId)).Include(p => p.Categories).ThenInclude(p => p.Category)
                                  .Include(p => p.Sizes).ThenInclude(p => p.Size).ToListAsync();
        }

        public async Task<ProductEntity?> GetById(int id)
        {
            return await _dataContext.Products.Where(p => p.PrdoductId == id).Include(p => p.Categories).ThenInclude(p => p.Category)
                                                                             .Include(p => p.Sizes).ThenInclude(p => p.Size).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetByStep(int offset = 0)
        {
            return await _dataContext.Products.Include(p => p.Categories).ThenInclude(p => p.Category)
                                              .Include(p => p.Sizes).ThenInclude(p => p.Size).Skip(offset).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetByTopSales()
        {
            List<ProductEntity> products = new List<ProductEntity>();
                        var list = await _dataContext.ProductOrder
                        .GroupBy(x => x.ProductId)
                        .Select(x => new { ProductId = x.Key, QuantitySum = x.Sum(a => a.Quantity)})
                        .OrderByDescending(x => x.QuantitySum)
                        .Select(x => x.ProductId)
                        .Take(3)
                        .ToListAsync();
            foreach (var productId in list)
            {
                ProductEntity? product = await GetById(productId);
                if (product is null) return null;
                products.Add(product);
            }

            return products;
        }

        public async Task<ProductEntity?> Insert(ProductEntity entity)
        {
            await _dataContext.Products.AddAsync(entity);
            if (entity.CategoriesId.Count > 0)
            {
                foreach (var categoryId in entity.CategoriesId)
                {
                    CategoryEntity? findEntity = await _dataContext.Categories.FindAsync(categoryId);
                    if (findEntity is null) return null;
                    await _dataContext.ProductCategory.AddAsync(new ProductCategoryEntity { CategoryId = categoryId, Product = entity });
                }
            }

            if(entity.SizeStock.Count > 0)
            {
                foreach (var sizeStock in entity.SizeStock)
                {
                    SizeEntity? findEntity = await _dataContext.Sizes.FindAsync(sizeStock.SizeId);
                    if (findEntity is null) return null;
                    await _dataContext.SizeProduct.AddAsync(new SizeProductEntity() { SizeId = sizeStock.SizeId, Stock = sizeStock.Stock, Product = entity });
                }
            }
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> SaveChange()
        {
            int rowUpdated = await _dataContext.SaveChangesAsync();
            return rowUpdated == 1;
        }

        public async Task<ProductEntity?> Update(ProductEntity oldEntity, ProductEntity modifiedEntity)
        {
            oldEntity.ModelName = modifiedEntity.ModelName;
            oldEntity.Brand = modifiedEntity.Brand;
            oldEntity.Description = modifiedEntity.Description;
            oldEntity.Price = modifiedEntity.Price;
            oldEntity.Discount = modifiedEntity.Discount;
            await _dataContext.SaveChangesAsync();
            return oldEntity;
        }

        public async Task<bool> UpdatePicture(ProductEntity product, string imageUrl)
        {
            product.Image = imageUrl;
            return true;
        }

        public async Task<bool> UpdateStock(int sizeId, int productId, int stock)
        {
            SizeProductEntity? sizeProduct = await _dataContext.SizeProduct.Where(sp => sp.ProductId == productId && sp.SizeId == sizeId).FirstOrDefaultAsync();
            if (sizeProduct is null) return false;

            sizeProduct.Stock = stock;
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
