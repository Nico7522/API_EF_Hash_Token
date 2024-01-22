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
        public int ProductId { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal ReductionPerProduct { get; set; }

    }
}
