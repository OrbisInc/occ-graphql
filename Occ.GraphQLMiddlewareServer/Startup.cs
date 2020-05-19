using GraphQL;
using GraphQL.DataLoader;
using GraphQL.NewtonsoftJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Occ.Data;
using Occ.Data.Repositories;
using Occ.GraphQLMiddlewareServer.GraphQL;
using Occ.GraphQLMiddlewareServer.GraphQL.Types;

namespace Occ.GraphQLMiddlewareServer
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
            _configuration  = builder.Build();
            _env = env;
        }

 
        public void ConfigureServices(IServiceCollection services)
        {

         
            services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
            services.AddDbContext<DatabaseContext>(options =>
              options.UseSqlServer(_configuration.GetConnectionString("GraphQLDB")));
            services.AddScoped<OrderRepository>();
            services.AddScoped<OrderItemRepository>();
            services.AddScoped<ISchema, GraphQLSchema>();
            services.AddScoped<OrderType>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddLogging(builder => builder.AddConsole());

            services.AddCors(options =>
                                options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()));
            services.AddLogging(builder => builder.AddConsole());
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
         //   services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                dbContext.Database.Migrate();
            }
            dbContext.Seed();

          

            app.UseCors("AllowAll"); 
            app.UseMiddleware<GraphQLMiddleware>(new GraphQLSettings(true, ctx => new GraphQLUserContext(ctx.User)));
            app.UseDefaultFiles();
            app.UseStaticFiles();


        }
    }
}
