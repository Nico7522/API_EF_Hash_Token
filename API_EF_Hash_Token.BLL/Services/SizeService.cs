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
    public class SizeService : ISizeService
    {

        private readonly ISizeRepository _sizeRepository;

        public SizeService(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;   
        }
        public async Task<SizeModel?> Delete(int id)
        {
            SizeEntity? sizeToDelete = await _sizeRepository.GetById(id);
            if(sizeToDelete is null) return null;

            SizeModel? deletedSize = await _sizeRepository.Delete(sizeToDelete).ContinueWith(r => r.Result?.ToSizeModel());
            return deletedSize;
        }

        public async Task<IEnumerable<SizeModel>> GetAll()
        {
            return await _sizeRepository.GetAll().ContinueWith(r => r.Result.Select(s => s.ToSizeModel()));
        }

        public async Task<SizeModel?> GetById(int id)
        {
            return await _sizeRepository.GetById(id).ContinueWith(r => r.Result?.ToSizeModel());
        }

        public async Task<SizeModel?> Insert(SizeModel model)
        {
            SizeModel? insertedSize = await _sizeRepository.Insert(model.ToSizeEntity()).ContinueWith(r => r.Result?.ToSizeModel());
            return insertedSize;
        }

        public async Task<SizeModel?> Update(SizeModel modifiedSize, int id)
        {
            SizeEntity? sizeToUpdate = await _sizeRepository.GetById(id);
            if (sizeToUpdate is null) return null;

            SizeModel? updatedSize = await _sizeRepository.Update(sizeToUpdate, modifiedSize.ToSizeEntity()).ContinueWith(r => r.Result?.ToSizeModel());
            return updatedSize;
        }
    }
}
