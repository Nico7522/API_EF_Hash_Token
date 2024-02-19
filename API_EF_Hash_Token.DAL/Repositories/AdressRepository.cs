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
    public class AdressRepository : IAdressRepository
    {
        private readonly DataContext _dataContext;

        public AdressRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddUserAdress(AdressEntity adress, UserEntity user)
        {
            await _dataContext.Adresses.AddAsync(adress);
            user.Addresses.Add(new UserAdressEntity { User = user });
            int row = await _dataContext.SaveChangesAsync().ContinueWith(r => r.Result);
            return row > 0 ? true : false;

        }

        public async Task<bool> CheckIfExist(AdressEntity entityToFind)
        {
            AdressEntity? isAdressExist = await _dataContext.Adresses.Where(a => a.Number == entityToFind.Number && a.Street == entityToFind.Street && a.CityName == entityToFind.CityName && a.Country == entityToFind.Country).SingleOrDefaultAsync();

            return isAdressExist is null ? false : true;
        }

        public async Task<AdressEntity?> Delete(AdressEntity entity)
        {
            //AdressEntity? adressToDelete = await GetById(id);
            _dataContext.Adresses.Remove(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<AdressEntity>> GetAll()
        {
           IEnumerable<AdressEntity> adresses = await _dataContext.Adresses.ToListAsync();
            return adresses;
        }

        public async Task<AdressEntity?> GetById(int id)
        {
           AdressEntity? adress = await _dataContext.Adresses.FindAsync(id);
            return adress;
        }

        public async Task<AdressEntity?> Insert(AdressEntity entity)
        {
            await _dataContext.Adresses.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<AdressEntity?> Update(AdressEntity oldEntity, AdressEntity modifiedEntity)
        {
            oldEntity.Street = modifiedEntity.Street;
            oldEntity.Number = modifiedEntity.Number;
            oldEntity.CityName = modifiedEntity.CityName;
            oldEntity.Country = modifiedEntity.Country;
            await _dataContext.SaveChangesAsync();
            return oldEntity;
        }
    }
}
