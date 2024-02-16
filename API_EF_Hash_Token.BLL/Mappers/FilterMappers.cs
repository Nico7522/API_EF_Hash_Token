using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Mappers
{
    internal static class FilterMappers
    {
        internal static FilterEntity ToFilterEntity(this FilterModel filterModel)
        {
            return new FilterEntity()
            {
                ModelName = filterModel.ModelName ?? null,
                Category = filterModel.Category ?? null,
                Sexe = filterModel.Sexe ?? null,
                Brand = filterModel.Brand ?? null,
            };
        }
    }
}
