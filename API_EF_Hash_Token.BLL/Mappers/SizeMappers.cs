using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Mappers
{
    internal static class SizeMappers
    {

        internal static SizeModel ToSizeModel(this SizeEntity entity)
        {
            return new SizeModel(entity.SizeId, entity.Size);
        }

        internal static SizeEntity ToSizeEntity(this SizeModel model)
        {
            return new SizeEntity() { Size = model.Size };
        }
    }
}
