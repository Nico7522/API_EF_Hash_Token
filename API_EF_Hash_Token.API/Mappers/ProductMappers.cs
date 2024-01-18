using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.BLL.Models;

namespace API_EF_Hash_Token.API.Mappers
{
    internal static class ProductMappers
    {

        internal static ProductDTO ToProductDTO(this ProductModel model)
        {
            return new ProductDTO() {
            
                ProductId = model.ProductId,    
                ModelName = model.ModelName,
                Description = model.Description,
                Brand = model.Brand,
                Price = model.Price,
                Discount = model.Discount,
                Sexe = model.Sexe,
                Categories =  model.Categories?.Select(c => c.ToCategoryDTO()).ToList() ?? new List<CategoryDTO>(),
            };
        }

        internal static ProductModel ToProductModel(this CreateProductForm form)
        {
            return new ProductModel(form.ModelName, form.Description, form.Brand, form.Sexe, form.Price, form.Discount); 
        }

        internal static ProductModel ToProductModel(this UpdateProductForm form)
        {
            return new ProductModel(form.ModelName, form.Description, form.Brand, form.Sexe, form.Price, form.Discount);
        }
    }
}
