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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<IEnumerable<ProductEntity>> GetByBrand(string brand)
        {
            return await _dataContext.Products.Where(p => brand.Contains(p.Brand.ToLower())).Include(p => p.Categories).ThenInclude(c => c.Category)
                                              .Include(p => p.Sizes).ThenInclude(p => p.Size).ToListAsync();
        }
    

        public async Task<IEnumerable<ProductEntity>> GetByCategory(string category)
        {
            return await _dataContext.Products.Where(p => p.Categories.Any(c => category.Contains(c.Category.CategoryName))).Include(p => p.Categories).ThenInclude(c => c.Category)
                                              .Include(p => p.Sizes).ThenInclude(p => p.Size).ToListAsync();
        }

        public async Task<ProductEntity?> GetById(int id)
        {
            return await _dataContext.Products.Where(p => p.PrdoductId == id).Include(p => p.Categories).ThenInclude(p => p.Category)
                                                                             .Include(p => p.Sizes).ThenInclude(p => p.Size).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetByPrice(decimal minPrice, decimal maxPrice)
        {
            return await _dataContext.Products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).Include(p => p.Categories).ThenInclude(p => p.Category)
                                              .Include(p => p.Sizes).ThenInclude(p => p.Size).ToListAsync();
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
            oldEntity.Sexe = modifiedEntity.Sexe;
            oldEntity.Discount = modifiedEntity.Discount;
            await _dataContext.SaveChangesAsync();
            return oldEntity;
        }

        public async Task<ProductEntity?> AddCategoryToProduct(ProductEntity product, List<CategoryEntity> categories)
        {
            // Try Catch pour ne pas planter le programme en cas d'insertion d'une catégorie déjà liée.
            try
            {
                foreach (var category in categories)
                {
                    product.Categories.Add(new ProductCategoryEntity { Category = category });
                }
                await _dataContext.SaveChangesAsync();

                return product;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public string? UpdatePicture(ProductEntity product, string imageUrl)
        {
            product.Image = imageUrl;
            return product.Image;
        }

        public async Task<ProductEntity?> UpdateStock(SizeEntity size, ProductEntity productToUpdate, int stock)
        {
            SizeProductEntity? sizeProduct = await _dataContext.SizeProduct.Where(sp => sp.Product == productToUpdate && sp.Size == size).FirstOrDefaultAsync();
            if (sizeProduct is null) return null;
            ProductEntity? product = sizeProduct.Product;

            sizeProduct.Stock = stock;
            await _dataContext.SaveChangesAsync();
            return product;
        }

        public IEnumerable<ProductEntity> Filter(FilterEntity filter)
        {

            IQueryable<ProductEntity> products =  _dataContext.Products.Include(p => p.Categories).ThenInclude(p => p.Category)
                                                                       .Include(p => p.Sizes).ThenInclude(p => p.Size);

            if (!string.IsNullOrEmpty(filter.ModelName))
            {
                products = products.Where(p => p.ModelName.Contains(filter.ModelName));
            }

            if (!string.IsNullOrEmpty(filter.Sexe))
            {
                products = products.Where(p => p.Sexe.Contains(filter.Sexe));
            }

            if (!string.IsNullOrEmpty(filter.Brand))
            {
                products = products.Where(p => p.Brand.Contains(filter.Brand));
            }

            if (!string.IsNullOrEmpty(filter.Category))
            {
                products =  products.Where(p => p.Categories.Any(c => filter.Category.Contains(c.Category.CategoryName)));
            }

            return products;

        }

        public async Task<bool> RemoveCategoryFromProduct(ProductEntity product, CategoryEntity categoryToRemove)
        {
            ProductCategoryEntity? category = await _dataContext.ProductCategory.FirstOrDefaultAsync(c => c.Product == product && c.Category == categoryToRemove);

            if (category is not null)
            {
                product.Categories.Remove(category);
                await _dataContext.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<ProductEntity?> AddSizeToProduct(ProductEntity product, SizeEntity sizeToAdd, int stock) {

            try
            {
            product.Sizes.Add(new SizeProductEntity { Size = sizeToAdd, Stock = stock });
            await _dataContext.SaveChangesAsync();
            return product;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<bool> RemoveSizeFromProduct(ProductEntity product, SizeEntity sizeToRemove)
        {
            SizeProductEntity? size = await _dataContext.SizeProduct.FirstOrDefaultAsync(s => s.Product == product && s.Size == sizeToRemove);
            
            if (size is not null)
            {
                product.Sizes.Remove(size);
                await _dataContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
