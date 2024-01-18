using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.BLL.Models;

namespace API_EF_Hash_Token.API.Mappers
{
    internal static class CategoryMappers
    {

        internal static CategoryDTO ToCategoryDTO(this CategoryModel model)
        {
            return new CategoryDTO() { CategoryId = model.CategoryId, CategoryName = model.CategoryName, Description = model.Description };
        }

        internal static CategoryModel ToCategoryModel(this CreateCategoryForm form)
        {
            return new CategoryModel() { CategoryName = form.CategoryName, Description = form.Description };
        }

        internal static CategoryModel ToCategoryModel(this UpdateCategoryForm form)
        {
            return new CategoryModel() { CategoryName = form.CategoryName, Description = form.Description };
        }

        internal static CategoryModel ToCategoryModel(this CategoryDTO dto)
        {
            return new CategoryModel() { CategoryName = dto.CategoryName, Description = dto.Description };
        }
    }
}
