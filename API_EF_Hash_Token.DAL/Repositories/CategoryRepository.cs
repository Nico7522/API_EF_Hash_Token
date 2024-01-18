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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<CategoryEntity?> Delete(CategoryEntity entity)
        {
             _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
            return entity;

        }

        public async Task<IEnumerable<CategoryEntity>> GetAll()
        {
            return await _dataContext.Categories.ToListAsync();
        }

        public async Task<CategoryEntity?> GetById(int id)
        {
            return await _dataContext.Categories.FindAsync(id);
        }

        public async Task<CategoryEntity?> Insert(CategoryEntity entity)
        {
            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<CategoryEntity?> Update(CategoryEntity oldEntity, CategoryEntity modifiedEntity)
        {
            oldEntity.CategoryName = modifiedEntity.CategoryName;
            oldEntity.Description = modifiedEntity.Description;
            await _dataContext.SaveChangesAsync();
            return oldEntity;
        }
    }
}
