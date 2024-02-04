using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.DAL.Class;
using API_EF_Hash_Token.DAL.Entities;

namespace API_EF_Hash_Token.BLL.Mappers
{
    internal static class ProductMappers
    {
        internal static ProductModel ToProductModel(this ProductEntity entity)
        {
            #pragma warning disable CS8604 // Possible null reference argument.
            return new ProductModel(entity.ModelName, entity.Description, entity.Brand, entity.Sexe, entity.Image, entity.Price, entity.Discount, entity.PrdoductId, entity.Categories.Where(c => c.Category != null).Select(c => c.Category.ToCategoryModel()).ToList(), entity.Sizes.Where(s => s.Size != null).Select(s => s.Size.ToSizeModel(s.Stock)).ToList());
        }


        // Mapper pour retourner l'entité créee car elle ne renvoie pas de liste avec les catégories
        //internal static ProductModel ToProductModelResponse(this ProductEntity entity)
        //{
        //    return new ProductModel(entity.ModelName, entity.Description, entity.Brand, entity.Sexe, entity.Price, entity.Discount, entity.PrdoductId);
        //}

        internal static ProductEntity ToProductEntity(this ProductModel model, List<int>? categoriesId = null, List<SizeModel>? sizeStock = null)
        {
            return new ProductEntity() {

                ModelName = model.ModelName,
                Description = model.Description,
                Brand = model.Brand,
                Sexe = model.Sexe,
                Image = model.Image,
                Price = model.Price,
                Discount = model.Discount,
                CategoriesId = categoriesId.ToList(),
                SizeStock = sizeStock.Select(st => st.ToSizeStock()).ToList() ?? new List<SizeStock>()
            };
        }
    }
}
