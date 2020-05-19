using GraphQL;
using GraphQL.Types;
using Occ.Data.Repositories;
using Occ.GraphQLMiddlewareServer.GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Occ.GraphQLMiddlewareServer.GraphQL
{
    public class GraphQLQueries : ObjectGraphType
    {




        public GraphQLQueries(OrderRepository orderRepository,
                              OrderItemRepository orderItemRepository)
        {

            #region Order

            Field<ListGraphType<OrderType>>(
               "orders",
               resolve: context => orderRepository.GetAll());

            Field<OrderType>(
                "order",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return orderRepository.GetOne(id);

                });


            #endregion


            #region OrderItems

            Field<ListGraphType<OrderItemType>>(
                "orderItems",
                resolve: context => orderItemRepository.GetAll());

            Field<OrderItemType>(
                "orderItemsForOrder",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return orderItemRepository.GetForOrder(id);

                });



            #endregion

        }

    }
}
