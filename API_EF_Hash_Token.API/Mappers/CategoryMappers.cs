using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.BLL.Models;

namespace API_EF_Hash_Token.API.Mappers
{
    internal static class CategoryMappers
    {

        internal static CategoryDTO ToCategoryDTO(this CategoryModel model)
        {
            return new CategoryDTO() { CategoryId = model.CategoryId, CategoryName = model.CategoryName, Description = model.Description };
        }
    }
}
