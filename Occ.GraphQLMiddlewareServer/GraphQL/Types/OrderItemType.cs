using GraphQL.Types;
using Occ.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Occ.GraphQLMiddlewareServer.GraphQL.Types
{
    public class OrderItemType :  ObjectGraphType<OrderItem>
    {
        public OrderItemType ()
        {
            Field(t => t.OrderItemId);
            Field(t => t.OrderId);
            Field(t => t.Quantity);
            Field(t => t.ProductId);
            Field(t => t.Notes);

        }


    }
}
