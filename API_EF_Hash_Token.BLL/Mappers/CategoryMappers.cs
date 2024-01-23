using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Mappers
{
    internal static class CategoryMappers
    {

        internal static CategoryModel ToCategoryModel(this CategoryEntity entity)
        {
            return new CategoryModel(entity.CategoryId, entity.CategoryName, entity.Description);
        }

        internal static CategoryEntity ToCategoryEntity(this CategoryModel entity)
        {
            return new CategoryEntity() { CategoryName = entity.CategoryName, Description = entity.Description };
        }

        internal static CategoryEntity ToAssociatedCategoryEntity(this CategoryModel entity)
        {
            return new CategoryEntity() { CategoryId = entity.CategoryId };
        }
    }
}
