using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Instrumentation;
using GraphQL.Types;
using Occ.Data.Entities;
using Occ.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Occ.GraphQLMiddlewareServer.GraphQL.Types
{
    public class OrderType :  ObjectGraphType<Order>
    {

      //   public OrderType(OrderItemRepository orderItemRepository)
        public OrderType()

        {

            Field(t => t.OrderId);
            Field(t => t.Notes).Description("Any Notes about the order"); ;
            Field<DateTime>(t => t.DateOrdered).Description("Date was ordered");
            Field(t => t.DeliveryAddress).Description("Delivery Address. Includes Street Number and Street Name");
            Field(t => t.DeliveryPostalCode).Description("Delivery PostCode. Canadian Postal Code"); 
            Field(t => t.DeliveryCity).Description("Delivery City");


            //Field<ListGraphType<OrderItemType>>(
            //    "orderItems",
            //    arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
            //    { Name = "id" }),
            //    resolve: context =>
            //    {
            //        var id = context.GetArgument<int>("OrderId");
            //        return orderItemRepository.GetForOrder(id);

            //    });



            //Field<ListGraphType<OrderItemType>>(
            //    "OrderItems",
            //    resolve: context =>
            //    {
            //        //var user = (ClaimsPrincipal)context.UserContext;
            //        var loader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, OrderItem>(
            //       "GetReviewsByProductId", orderItemRepository.GetForOrder());
            //        return loader.LoadAsync(context.Source.Id);
            //    });

        }

    }
}
