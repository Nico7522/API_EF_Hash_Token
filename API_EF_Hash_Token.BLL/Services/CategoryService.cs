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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryModel?> Delete(int id)
        {
            CategoryEntity? categoryToDelete = await _categoryRepository.GetById(id);
            if (categoryToDelete is null) return null;

            CategoryModel? deletedCategory = await _categoryRepository.Delete(categoryToDelete).ContinueWith(r => r.Result?.ToCategoryModel());
            return deletedCategory;
        }

        public async Task<IEnumerable<CategoryModel>> GetAll()
        {
            return await _categoryRepository.GetAll().ContinueWith(r => r.Result.Select(c => c.ToCategoryModel()));
        }

        public async Task<CategoryModel?> GetById(int id)
        {
            return await _categoryRepository.GetById(id).ContinueWith(r => r.Result?.ToCategoryModel());
        }

        public async Task<CategoryModel?> Insert(CategoryModel categoryModel)
        {
           CategoryModel? insertedCategory = await  _categoryRepository.Insert(categoryModel.ToCategoryEntity()).ContinueWith(r => r.Result?.ToCategoryModel());
           return insertedCategory;
        }

        public async Task<CategoryModel?> Update(CategoryModel modifiedCategory, int id)
        {
            CategoryEntity? categoryToUpdate = await _categoryRepository.GetById(id);
            if (categoryToUpdate is null) return null;

            CategoryModel? updatedCategory = await _categoryRepository.Update(categoryToUpdate, modifiedCategory.ToCategoryEntity()).ContinueWith(r => r.Result?.ToCategoryModel());
            return updatedCategory;

        }
       
    }
}
