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
            bool isAdressExist = await _adressRepository.CheckIfExist(adressModel.ToAdressEntity());
            if (isAdressExist) return null;


            AdressModel ? insetedAdress = await _adressRepository.Insert(adressModel.ToAdressEntity()).ContinueWith(r => r.Result?.ToAdressModel());
            return insetedAdress;
        }

        public async Task<AdressModel?> Update(AdressModel modifiedAdress, int id)
        {
            // Check si l'adresse existe
            AdressEntity? adressToUpdate = await _adressRepository.GetById(id);
            if(adressToUpdate is null) return null;

            // Check si après modification, l'adresse ne va pas faire doublon avec une autre.
            bool isAdressExist = await _adressRepository.CheckIfExist(modifiedAdress.ToAdressEntity());
            if (isAdressExist) return null;

            // Si tout est ok, on update
            return await _adressRepository.Update(adressToUpdate, modifiedAdress.ToAdressEntity()).ContinueWith(r => r.Result?.ToAdressModel());
        }
    }
}
