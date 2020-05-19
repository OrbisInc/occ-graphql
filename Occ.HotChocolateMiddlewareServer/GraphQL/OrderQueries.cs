using HotChocolate;
using Microsoft.EntityFrameworkCore;
using Occ.Data;
using Occ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Occ.HotChocolateMiddlewareServer.GraphQL
{
    public class OrderQueries
    {

        // This is example of writing own custom queries.


        public async Task<List<Order>> GetOrders([Service] DatabaseContext dbContext, int? skip, int? take) =>
            await dbContext
                   .Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                   .Skip(skip ?? 0)
                   .Take(take ?? 1000) 
                   .AsNoTracking()
                   .OrderBy(o => o.DateOrdered)
                   .ToListAsync();


        public async Task<Order> GetOrder([Service] DatabaseContext dbContext, int orderId) =>
            await dbContext
                    .Orders
                    .AsNoTracking()
                    .SingleOrDefaultAsync(o => o.OrderId == orderId);
       
    }
}
