using Microsoft.EntityFrameworkCore;
using Occ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Occ.Data.Repositories
{
    public class OrderRepository
    {

        private readonly DatabaseContext _dbContext;

        public OrderRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Order>> GetAll()
        {
            return _dbContext.Orders.ToListAsync();
        }


        public Task<List<Order>> GetAllWithChildObjects()
        {
            return _dbContext.Orders
                    .Include(o => o.OrderItems).ThenInclude(o => o.Product)
                    .ToListAsync();
        }

        public Task<Order> GetOne(int orderId)
        {
            return _dbContext.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
        }
    }
}
