﻿using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.BLL.Models;

namespace API_EF_Hash_Token.API.Mappers
{
    internal static class SizeMappers
    {
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
    }
}
