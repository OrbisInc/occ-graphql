# occ-graphql
GraphQL Prototypes, using Entity Framework/Sql Server Database for the data source and .Net Core 3.1. 

Evaluating implementations GraphQL implementations ( graphql-dotnet and  hotchocolate)


There are two examples, one using graphql-dotnet and one using hotchocolate.

graphql-dotnet
 https://github.com/graphql-dotnet/graphql-dotnet
This library has been out the longest.
Unfortunately, does not work well with .Net Core 3.1, and is not as active as the Hotchocolate platform.

To run the Occ.GraphQLMiddlewareServer (graphql-dotnet):
In project Occ.GraphQLMiddlewareServer, Edit the appsettings.json file and edit the GraphQLDB sql connection string for your local instance of Sql Server.

Run : Occ.GraphQLMiddlewareServer 

A browser should appear , where you can place in 
