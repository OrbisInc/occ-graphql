using Microsoft.EntityFrameworkCore;
using Occ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occ.Data.Repositories
{
    public class OrderItemRepository
    {

        private readonly DatabaseContext _dbContext;


        public OrderItemRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<OrderItem>> GetAll()
        {
            return await _dbContext.OrderItems.ToListAsync();
        }


        public async Task<List<OrderItem>> GetForOrder(int orderId)
        {
            return await _dbContext.OrderItems.Where(o => o.OrderId == orderId).ToListAsync(); 
        }

        public async Task<ILookup<int, OrderItem>> GetForOrders(IEnumerable<int> orderIds)
        {
            var orderItems = await _dbContext.OrderItems.Where(pr => orderIds.Contains(pr.OrderId)).ToListAsync();
            return orderItems.ToLookup(r => r.OrderItemId);
        }


    }
}
