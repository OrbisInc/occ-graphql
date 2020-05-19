using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Occ.Data;
using Occ.HotChocolateMiddlewareServer.GraphQL;

namespace Occ.HotChocolateMiddlewareServer
{
    public class Startup
    {

        private IWebHostEnvironment _env;
        public readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {


            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            _configuration = builder.Build();
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("GraphQLDB")));

            //services.AddGraphQL(
            //  SchemaBuilder.New()
            //   .AddQueryType<OrderQueryType>() 
            //  .Create());
            services.AddGraphQL(
        SchemaBuilder.New()
            .AddQueryType<OrderQueriesUsingAttributes>()
            .Create(),
            new QueryExecutionOptions { ForceSerialExecution = true });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext dbContext)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();


            using (var serviceScope = app.ApplicationServices
               .GetRequiredService<IServiceScopeFactory>()
               .CreateScope())
            {
                dbContext.Database.Migrate();
            }
            dbContext.Seed();


            app
              .UseRouting()
              .UseWebSockets()
              .UseGraphQL()
              .UsePlayground();
        }
    }
}
