using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Occ.Data;
using Occ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Occ.HotChocolateMiddlewareServer.GraphQL
{

    /// <summary>
    /// Attributes will allow Selection. Filtering and Sorting of 
    /// </summary>
    public class OrderQueriesUsingAttributes
    {
      //  [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting(SortType = typeof(Order))]
        public IQueryable<Order> GetOrders([Service]DatabaseContext context) =>
            context.Orders;

    }
}
