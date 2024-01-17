using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Mappers
{
    internal static class ProductMappers
    {
        internal static ProductModel ToProductModel(this ProductEntity entity)
        {
            return new ProductModel(entity.ModelName, entity.Description, entity.Brand, entity.Sexe, entity.Price, entity.Discount, entity.Categories.Select(c => c.Category.ToCategoryModel()).ToList(), entity.PrdoductId);
        }

        internal static ProductEntity ToProductEntity(this ProductModel model)
        {
            return new ProductEntity() {
                
            ModelName = model.ModelName,
            Description = model.Description,
            Brand = model.Brand,
            Sexe = model.Sexe,
            Price = model.Price,
            Discount = model.Discount,
            };
        }
    }
}
