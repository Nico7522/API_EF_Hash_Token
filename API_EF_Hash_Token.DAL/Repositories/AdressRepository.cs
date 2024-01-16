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


        public async Task<AdressEntity?> Delete(int id)
        {
            AdressEntity? adressToDelete = await GetById(id);

            if (adressToDelete is null)
                return null;

            _dataContext.Adresses.Remove(adressToDelete);
            await _dataContext.SaveChangesAsync();

            return adressToDelete;
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
            int rowInserted = await _dataContext.SaveChangesAsync();
            return rowInserted == 1 ? entity : null;
        }

        public async Task<AdressEntity?> Update(AdressEntity entity, int id)
        {
            AdressEntity? adressToUpdate = await _dataContext.Adresses.FindAsync(id);
            if (adressToUpdate is null)
                return null;

            adressToUpdate.Street = entity.Street;
            adressToUpdate.Number = entity.Number;
            adressToUpdate.CityName = entity.CityName;
            adressToUpdate.Country = entity.Country;
            await _dataContext.SaveChangesAsync();
            return adressToUpdate;
        }
    }
}
