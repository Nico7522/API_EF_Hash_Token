using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Entities
{
    public class SizeProductEntity
    {
        public int SizeId { get; set; }
        public SizeEntity Size { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
