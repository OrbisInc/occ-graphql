using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Occ.HotChocolateMiddlewareServer.GraphQL
{
    public class OrderQueriesType : ObjectType<OrderQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<OrderQueries> descriptor)
        {
            base.Configure(descriptor);

            descriptor
              .Field(o => o.GetOrders(default, default,default));


            descriptor
                .Field(f => f.GetOrder(default, default))
                .Argument("orderId", a => a.Type<IntType>());
        }


    }

}
