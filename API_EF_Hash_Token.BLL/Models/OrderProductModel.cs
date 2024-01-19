using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Models
{
    public class OrderProductModel 
    {
        // Mettre les données du produits avec la quantité
        public string ModelName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

   
    }
}
