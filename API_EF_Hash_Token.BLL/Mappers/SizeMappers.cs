using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Class;
using API_EF_Hash_Token.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Mappers
{
    internal static class SizeMappers
    {

        internal static SizeModel ToSizeModel(this SizeEntity entity, int stock = 0)
        {
            return new SizeModel(entity.SizeId, entity.Size, stock);
        }

        internal static SizeEntity ToSizeEntity(this SizeModel model)
        {
            return new SizeEntity() { Size = model.Size };
        }

        internal static SizeStock ToSizeStock(this SizeModel model)
        {
            return new SizeStock()
            {
                SizeId = model.SizeId,
                Stock = model.Stock,
            };
        }

        //internal static SizeStockModel ToSizeStockModel(this SizeEntity entity, ProductEntity stock)
        //{
        //    return new SizeStockModel(entity.Size, stock.Sizes.Select(s => s.Stock));
        //}
       
    }
}
