using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRIF.CodeTest2.API.Contexts;
using CRIF.CodeTest2.API.Repositories;
using CRIF.CodeTest2.API.Services;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CRIF.CodeTest2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddIdentityServer()
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients);
            services.AddControllers();
            services.AddSingleton<INovelRepository, NovelRepository>();
            services.AddTransient<INovelService, NovelService>();
            ConfigureEntityFramework(services);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "api1");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void ConfigureEntityFramework(IServiceCollection services)
        {
            var databaseName = Configuration["EntityFramework:DatabaseName"];

            services.AddDbContext<NovelDatabaseContext>(options =>
                options.UseInMemoryDatabase(databaseName));
        }

        public static class Config
        {
            public static IEnumerable<ApiScope> ApiScopes =>
                new List<ApiScope>
                {
            new ApiScope("api1", "My API")
                };

            public static IEnumerable<Client> Clients =>
    new List<Client>
    {
        new Client
        {
            ClientId = "client",

            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ClientCredentials,

            // secret for authentication
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },

            // scopes that client has access to
            AllowedScopes = { "api1" }
        }
    };
        }
        
    }
}
