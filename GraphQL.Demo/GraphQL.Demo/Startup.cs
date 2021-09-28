using GraphQL.Demo.Database;
using GraphQL.Demo.GraphQLTypes;
using GraphQL.Demo.Repository;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<MySocialDbContext>(c => c.UseSqlite("Data Source = MySocialDatabase.db"));

            services.AddGraphQLServer().AddQueryType<SocialDbQueryType>()
            .AddMutationType<SocialDbMutationType>()
            .AddSubscriptionType<SocialDbSubscriptionType>()
            .ModifyOptions(options =>
            {
                options.DefaultResolverStrategy = ExecutionStrategy.Serial;
            });

            services.AddInMemorySubscriptions();

            services.AddScoped<UsersRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseWebSockets();

            app.UseRouting().UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
