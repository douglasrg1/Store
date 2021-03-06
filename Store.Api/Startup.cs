﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Infra.Repository;
using Store.Infra.StoreContext.DataContext;
using Store.Infra.StoreContext.Services;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Configuration;
using System.IO;
using Store.Shared;
using Store.Infra.StoreContext.Repositories;

namespace Store.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("AppSettings.json");

            Configuration = builder.Build();

            services.AddMvc();

            services.AddResponseCompression();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandlers, CustomerHandlers>();
            services.AddTransient<OrderHandlers, OrderHandlers>();
            services.AddScoped<StoreDataContext, StoreDataContext>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "StoreApi", Version = "V1" });
            });

            ConnectionSettings.ConnectionString = Configuration["connectionString"];
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            app.UseResponseCompression();

            app.UseSwagger();

            app.UseSwaggerUI(X =>
            {
                X.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreApi - V1");
                X.DefaultModelExpandDepth(0);
                X.DefaultModelsExpandDepth(-1);
            });


        }
    }
}
