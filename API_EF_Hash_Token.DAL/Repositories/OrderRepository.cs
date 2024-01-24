using API_EF_Hash_Token.DAL.Domain;
using API_EF_Hash_Token.DAL.Entities;
using API_EF_Hash_Token.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<OrderEntity>> GetAll()
        {
            return await _dataContext.Orders.Include(o => o.User).Include(c => c.Products).ThenInclude(p => p.Size).Include(p => p.Products).ThenInclude(p => p.Product).ToListAsync();
        }

        public async Task<IEnumerable<OrderEntity>> GetByUserEmail(string email)
        {
            return await _dataContext.Orders.Where(o => o.User.Email == email).Include(c => c.User).Include(c => c.Products).ThenInclude(p => p.Product).ToListAsync();
        }

        public async Task<IEnumerable<OrderEntity>> GetByUserId(int userId)
        {
            return await _dataContext.Orders.Where(o => o.UserId == userId).Include(c => c.User).Include(c => c.Products).ThenInclude(p => p.Product).ToListAsync();
        }

        public async Task<OrderEntity?> Insert(OrderEntity entity)
        {
            await _dataContext.Orders.AddAsync(entity);
            foreach (var po in entity.Products)
            {
                bool isDecreased = await DecreaseStock(po.SizeId, po.ProductId, po.Quantity).ContinueWith(r => r.Result);
                if (!isDecreased) return null;

                await _dataContext.ProductOrder.AddAsync(po);
            }
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        private async Task<bool> DecreaseStock(int sizeId,int productId, int quantity)
        {
            SizeProductEntity? product = await _dataContext.SizeProduct.Where(ps => ps.ProductId == productId && ps.SizeId == sizeId).SingleOrDefaultAsync();
            if (product is null || product.Stock == 0) return false;

            if (product.Stock - quantity < 0) return false;

            product.Stock -= quantity;

            return true;
        }
    }
}
