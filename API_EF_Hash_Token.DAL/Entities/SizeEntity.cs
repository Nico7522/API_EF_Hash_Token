using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Entities
{
    public class SizeEntity
    {
        public int SizeId { get; set; }
        public int Size { get; set; }
        public List<SizeProductEntity> Products { get; set; }
        public List<ProductOrderEntity> Orders { get; set; }
    }
}
