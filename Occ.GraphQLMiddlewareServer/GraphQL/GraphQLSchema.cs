using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using Occ.Data.Repositories;
//using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Occ.GraphQLMiddlewareServer.GraphQL
{
    public class GraphQLSchema: Schema
    {
        //   public GraphQLSchema(IDependencyResolver resolver) : base(resolver)
        ////  public GraphQLSchema(IServiceProvider provider) : base(provider)
        //  {
        //      Query = resolver.Resolve<GraphQLQueries>();
        //      //  Mutation = resolver.Resolve<GraphQLMutations>();

        //  }
        

        public GraphQLSchema(OrderRepository orderRepository, OrderItemRepository orderItemRepository ) => Query = new GraphQLQueries(orderRepository, orderItemRepository);


    }
}
