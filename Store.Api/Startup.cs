using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Infra.Repository;
using Store.Infra.StoreContext.DataContext;
using Store.Infra.StoreContext.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace Store.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddResponseCompression();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandlers, CustomerHandlers>();
            services.AddScoped<StoreDataContext, StoreDataContext>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "StoreApi", Version = "V1" });
            });
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
