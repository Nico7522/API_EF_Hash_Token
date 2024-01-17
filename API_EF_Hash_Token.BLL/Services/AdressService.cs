using API_EF_Hash_Token.BLL.IInterfaces;
using API_EF_Hash_Token.BLL.Mappers;
using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Entities;
using API_EF_Hash_Token.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Services
{
    public class AdressService : IAdressService
    {
        private readonly IAdressRepository _adressRepository;

        public AdressService(IAdressRepository adressRepository)
        {
            _adressRepository = adressRepository;
        }

        public async Task<AdressModel?> Delete(int id)
        {
            AdressEntity? adressToDelete = await _adressRepository.GetById(id);
            if (adressToDelete is null) return null;
                

           AdressModel? deletedAdress = await _adressRepository.Delete(adressToDelete).ContinueWith(r => r.Result?.ToAdressModel());
           return deletedAdress;
        }

        public async Task<IEnumerable<AdressModel>> GetAll()
        {
            return await _adressRepository.GetAll().ContinueWith(r => r.Result.Select(a => a.ToAdressModel()));
        }

        public async Task<AdressModel?> GetById(int id)
        {
            return await _adressRepository.GetById(id).ContinueWith(r => r.Result?.ToAdressModel());
        }

        public async Task<AdressModel?> Insert(AdressModel adressModel)
        {
            AdressEntity? isAdressExist = await _adressRepository.CheckIfExist(adressModel.ToAdressEntity());
            if (isAdressExist is not null) return null;


            AdressModel ? insetedAdress = await _adressRepository.Insert(adressModel.ToAdressEntity()).ContinueWith(r => r.Result?.ToAdressModel());
            return insetedAdress;
        }

        public Task<AdressModel?> Update(AdressModel modifiedAdress, int id)
        {
            throw new NotImplementedException();
        }
    }
}
