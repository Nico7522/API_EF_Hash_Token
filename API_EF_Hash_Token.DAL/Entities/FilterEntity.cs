using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Entities
{
    public class FilterEntity
    {
        public string? ModelName { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? Sexe { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

    }
}
