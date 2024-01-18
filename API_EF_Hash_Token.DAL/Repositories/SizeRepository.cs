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
    public class SizeRepository : ISizeRepository
    {
        private readonly DataContext _dataContext;

        public SizeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<SizeEntity?> Delete(SizeEntity entity)
        {
            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<SizeEntity>> GetAll()
        {
            return await _dataContext.Sizes.ToListAsync();
        }

        public async Task<SizeEntity?> GetById(int id)
        {
            return await _dataContext.Sizes.FindAsync(id);
        }

        public async Task<SizeEntity?> Insert(SizeEntity entity)
        {
            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;

        }

        public async Task<SizeEntity?> Update(SizeEntity oldEntity, SizeEntity modifiedEntity)
        {
            oldEntity.Size = modifiedEntity.Size;
            await _dataContext.SaveChangesAsync();
            return oldEntity;
        }
    }
}
