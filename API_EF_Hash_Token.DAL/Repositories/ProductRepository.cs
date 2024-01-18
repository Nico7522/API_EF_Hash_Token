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

        public async Task<ProductEntity?> GetById(int id)
        {
            return await _dataContext.Products.Where(p => p.PrdoductId == id).Include(p => p.Categories).ThenInclude(p => p.Category).FirstOrDefaultAsync();
        }

        public async Task<ProductEntity?> Insert(ProductEntity entity)
        {
            await _dataContext.Products.AddAsync(entity);
            if (entity.CategoriesId.Count > 0)
            {
                foreach (var categoryId in entity.CategoriesId)
                {
                    await Console.Out.WriteLineAsync((char)categoryId);
                    await _dataContext.ProductCategory.AddAsync(new ProductCategoryEntity { CategoryId = categoryId, Product = entity });
                }
            }
            await _dataContext.SaveChangesAsync();
            return entity;
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
    }
}
