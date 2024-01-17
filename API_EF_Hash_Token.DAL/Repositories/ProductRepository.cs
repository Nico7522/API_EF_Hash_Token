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

        public Task<ProductEntity?> Delete(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            return await _dataContext.Products.Include(p => p.Categories).ThenInclude(p => p.Category).ToListAsync();
        }

        public async Task<ProductEntity?> GetById(int id)
        {
            return await _dataContext.Products.Where(p => p.PrdoductId == id).Include(p => p.Categories).ThenInclude(p => p.Category).FirstOrDefaultAsync();
        }

        public async Task<ProductEntity?> Insert(ProductEntity entity)
        {
            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public Task<ProductEntity?> Update(ProductEntity oldEntity, ProductEntity modifiedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
