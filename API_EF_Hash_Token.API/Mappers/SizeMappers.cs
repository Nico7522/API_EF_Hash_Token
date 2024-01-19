using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.BLL.Models;

namespace API_EF_Hash_Token.API.Mappers
{
    internal static class SizeMappers
    {
        internal static SizeStockDTO ToStockSizeDTO(this SizeModel model)
        {
            return new SizeStockDTO()
            {
                SizeId = model.SizeId,
                Size = model.Size,
                Stock = model.Stock,
            };
        }
        internal static SizeDTO ToSizeDTO(this SizeModel model)
        {
            return new SizeDTO()
            {
                SizeId = model.SizeId,
                Size = model.Size,
            };
        }

        internal static SizeModel ToSizeModel(this CreateSizeForm form)
        {
            return new SizeModel(form.Size);
        }

        internal static SizeModel ToSizeModel(this UpdateSizeForm form)
        {
            return new SizeModel(form.Size);
        }

        internal static SizeModel ToSizeModel(this SizeStockForm form) {
            return new SizeModel(form.SizeId, form.Stock);
        }
    }
}
