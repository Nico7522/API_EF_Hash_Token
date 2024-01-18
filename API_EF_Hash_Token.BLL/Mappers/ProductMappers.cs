using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Entities;

namespace API_EF_Hash_Token.BLL.Mappers
{
    internal static class ProductMappers
    {
        internal static ProductModel ToProductModel(this ProductEntity entity)
        {
            #pragma warning disable CS8604 // Possible null reference argument.
            return new ProductModel(entity.ModelName, entity.Description, entity.Brand, entity.Sexe, entity.Price, entity.Discount, entity.PrdoductId, entity.Categories?.Select(c => c.Category.ToCategoryModel()).ToList());
        }


        // Mapper pour retourner l'entité créee car elle ne renvoie pas de liste avec les catégories
        //internal static ProductModel ToProductModelResponse(this ProductEntity entity)
        //{
        //    return new ProductModel(entity.ModelName, entity.Description, entity.Brand, entity.Sexe, entity.Price, entity.Discount, entity.PrdoductId);
        //}

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
