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
            return await _dataContext.Orders.Include(c => c.User).Include(c => c.Products).ThenInclude(p => p.Product).ToListAsync();
        }

        public async Task<IEnumerable<OrderEntity>> GetByUser(string email)
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
            await _dataContext.SaveChangesAsync();
            return entity;
        }
    }
}
