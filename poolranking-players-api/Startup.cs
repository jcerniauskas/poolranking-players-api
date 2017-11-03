using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace poolranking_players_api
{
    public class Startup
    {
        private DocumentClient client;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            client = new DocumentClient(new Uri(Constants.EndpointUri), Constants.PrimaryKey);
            client.CreateDatabaseIfNotExistsAsync(new Database { Id = Constants.databaseName }).Wait();
            client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(Constants.databaseName), new DocumentCollection { Id = Constants.collectionName }).Wait();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
