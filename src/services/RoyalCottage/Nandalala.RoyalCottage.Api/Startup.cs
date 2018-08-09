using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using Nandalala.RoyalCottage.Api;
using Nandalala.RoyalCottage.Core;
using Nandalala.RoyalCottage.Data.Repositories;
using Nandalala.Framework.Couchbase;
using Nandalala.Paas.Core;
using System;

namespace RoyalCottage.WebApi
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
            services.AddMvc();
            //Swagger Registration - BEGIN
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
            //    {
            //        Title = "Nandalala.RoyalCottage.Api",
            //        Version = "v1",
            //        Description = "Platform's Product API",
            //        TermsOfService = "None"
            //    });
            //});
            ////Swagger Registration - END
            services.AddCors(options =>
            {
                options.AddPolicy("CORS",
                corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });

            services.AddOptions();
            
            //services.Configure<RoyalCottageConfiguration>(Configuration.GetSection("RoyalCottageConfiguration"));
            var RoyalCottageConfig = Configuration.GetSection("RoyalCottageConfiguration").Get<RoyalCottageConfiguration>();

            SecurityContext securityContext = new SecurityContext(
                            Guid.Parse("4a096a88-69ea-46b5-8909-442078fb3a16"),
                            Guid.Parse("fe5d2b85-b5f4-4f2b-8f59-f8623ab92a4e")
                            );

            ICouchbaseClient _client;
            ICouchbaseBucket _bucket;

            CouchbaseHelper.TryGet(RoyalCottageConfig.ServerUri, RoyalCottageConfig.UserName,
                RoyalCottageConfig.Password, out _client);
            _bucket = _client.GetBucket(RoyalCottageConfig.Bucket);

          
            services.AddTransient<IBroker, Broker>();
            
            
           
            Container container = new Container();
            container.RegisterSingleton(securityContext);
            container.Register<IDocumentRepository, DocumentRepository>();
            container.RegisterSingleton(_bucket);
            ContainerConfig.Configure(container);
            container.Verify();
            services.AddSingleton(container);

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseCors("CORS");
            app.UseMvc();
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nandalala.RoyalCottage.Api");

            //});
        }
    }
}