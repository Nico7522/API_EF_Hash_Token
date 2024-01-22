using API_EF_Hash_Token.BLL.Models;

namespace API_EF_Hash_Token.API.Forms
{
    public class CreateOrderForm
    {
        public int UserId { get; set; }
        public List<ProductOrderForm> OrderProduct { get; set; } = new List<ProductOrderForm>();
    }
}
