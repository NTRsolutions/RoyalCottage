﻿using Couchbase.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoyalCottage.Planning.Business;
using RoyalCottage.Framework.Couchbase;
using RoyalCottage.Framework.WebApi.Filters;
using System;

namespace RoyalCottage.Planning.WebApi
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
            services.AddCors(options =>
            {
                options.AddPolicy("CORS",
                corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader() //TODO: Restrict the headers to application specific ones
                .AllowCredentials());
            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("CORS"));
            });

            //Swagger Registration - BEGIN
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "RoyalCottage.Planning.WebApi",
                    Version = "v1",
                    Description = "CWB Platform's Planning API",
                    TermsOfService = "None"
                });
            });
            //Swagger Registration - END

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("CORS"));
            });


            //Couchbase Registration - BEGIN
            services
                .AddCouchbase(Configuration.GetSection("Couchbase"))
                .AddCouchbaseBucket<ICouchbaseBucketProvider>("Planning");
            services.AddSingleton<ICouchbaseBucket, CouchbaseBucket>();
            //Couchbase Registration - END


            //Application Types Registration - BEGIN
            services.AddSingleton<ApplicationContextFilter>();
            services.AddDomain();
            //Application Types Registration - END            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseMvc();
            app.UseCors("CORS");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RoyalCottage.Planning.WebApi");

            });

            // When application is stopped gracefully shutdown Couchbase connections
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                app.ApplicationServices.GetRequiredService<ICouchbaseLifetimeService>().Close();
            });
        }
    }
}
