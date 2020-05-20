# occ-graphql
GraphQL Prototypes, using Entity Framework/Sql Server Database for the data source and .Net Core 3.1. 

In this Repo, Evaluating GraphQL implementations ( graphql-dotnet and  hotchocolate)


There are two examples, one using graphql-dotnet and one using hotchocolate.
Both Examples, expose one endpoint, where can sumbit queries.

graphql-dotnet
https://github.com/graphql-dotnet/graphql-dotnet
This library has been out the longest.
Unfortunately, does not work well with .Net Core 3.1, and is not as active as the Hotchocolate platform.

To run the Occ.GraphQLMiddlewareServer (graphql-dotnet):
In project Occ.GraphQLMiddlewareServer, Edit the appsettings.json file and edit the GraphQLDB sql connection string for your local instance of Sql Server.

Run : Occ.GraphQLMiddlewareServer 

A browser should appear (https://localhost:5001/) GraphiQL, where you can place in sample queries/mutations.

Copy and paste sample queries from GraphQLSampleQueriesMutations.txt into the sample window.

For story CC-1084:
1) GraphQL can be properly configured in ASP.NET Core, yes, but when using .Net Core 3.1, using pre-release libraries. Additonally could not get all the Acceptance Criteria as below working properly. 

2) We can perform a basic query and retrieve the proper data:
Yes. In this example can query the order entity

3) We can perform aggregate queries, i.e. counts, sums, etc. : Not in sample, but could write custom linq query to do this

4) We can add custom SQL functions / bridge between queries and SQL : Not in sample, but could write custom linq query to do this.

5) It's efficient with complex trees of relationships (compare cache query speeds with and without GraphQL) : Could not get relationship query to work properly. Ie: in Entity model had Orders -> OrderItems -> Product relationship. Could not create GraphQL query to retrieve OrderItems or products.

6) GraphQL can perform filters, sorts, and pagination : Not in sample, but possible with custom linq queries. 

7) Can we implement proper security / roles for different tables & entities: There is only one endpoint exposed. No.

Summary : This was the first .Net Implementation of .Net Core. Looked promising with .Net Core 2.1, but recently, less activity on this repo. For .Net 3.1 to work, have to use a number of PreRelease Nuget packages. Conclusion, would not use this implementation right now.

Some other resources for : https://github.com/graphql-dotnet/graphql-dotnet



