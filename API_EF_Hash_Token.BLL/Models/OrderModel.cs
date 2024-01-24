using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Models
{
    public class OrderModel
    {
        public int OrderId { get; init; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public List<OrderProductModel> OrderProducts { get; set; } = new List<OrderProductModel>();
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalReduction { get; set; }

        /// <summary>
        /// Constructeur pour la création d'une commande
        /// </summary>
        /// <param name="userId">L'id de lutilisateur</param>
        /// <param name="totalReduction">La réduction total sur la commande</param>
        /// <param name="orderProducts">La liste de produits</param>
        public OrderModel(int userId, decimal totalReduction, List<OrderProductModel> orderProducts)
        {
            this.UserId = userId;
            this.TotalReduction = totalReduction;
            this.OrderProducts = orderProducts;
        }

        /// <summary>
        /// Constructeur pour la récupération des commandes
        /// </summary>
        /// <param name="userId">L'id de lutilisateur</param>
        /// <param name="totalReduction">La réduction total sur la commande</param>
        /// <param name="orderProducts">La liste de produits</param>
        public OrderModel(int orderid, int userId, UserModel user, List<OrderProductModel> orderProducts, decimal totalPrice, DateTime orderDate, decimal totalReduction)
            : this (userId, totalReduction, orderProducts )
        {
            this.OrderId = orderid;
            this.User = user;
            this.TotalPrice = totalPrice;
            this.OrderDate = orderDate; 
            this.TotalReduction = totalReduction;
        }



    }

   
}
