using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Models
{
    public class SizeStockModel
    {
        public int Size { get; set; }
        public int Stock { get; set; }

        public SizeStockModel(int size, int stock)
        {
            this.Size = size; 
            this.Stock = stock;
        }
    }
}
