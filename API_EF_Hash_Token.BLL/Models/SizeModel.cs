﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Models
{
    public class SizeModel
    {
        public int SizeId { get; init; }
        public int Size { get; set; }
        public int Stock { get; set; }


        public SizeModel(int size)
        {
            this.Size = size;
        }
        public SizeModel(int sizeId, int stock = 0)
        {
            this.SizeId = sizeId;
            Stock = stock;

        }
        public SizeModel(int sizeId, int size, int stock = 0)
        {
            this.SizeId = sizeId;
            this.Size = size;
            Stock = stock;

        }
    }
}
