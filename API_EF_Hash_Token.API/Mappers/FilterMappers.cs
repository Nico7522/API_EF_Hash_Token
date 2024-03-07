using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.BLL.Models;

namespace API_EF_Hash_Token.API.Mappers
{
    internal static class FilterMappers
    {
        internal static FilterModel ToFilterModel(this FilterForm form)
        {
            return new FilterModel(form.ModelName, form.Category,form.Brand, form.Sexe, form.MinPrice, form.MaxPrice);
        }
    }
}
