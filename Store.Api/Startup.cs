using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Infra.DataContexts;
using Store.Infra.StoreContext.Repositories;
using Elmah.Io.AspNetCore;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using Store.Shared;

namespace Store.Api
{
  public class Startup
  {
    public static IConfiguration Configuration { get; set; }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json");

        Configuration = builder.Build();
        
      services.AddMvc();
      services.AddMvc(option => option.EnableEndpointRouting = false);

      services.AddResponseCompression();

      services.AddScoped<DataContext, DataContext>();
      services.AddTransient<ICustomerRepository, CustomerRepository>();
      services.AddTransient<IEmailService, EmailService>();
      services.AddTransient<CustomerHandler, CustomerHandler>();

      services.AddSwaggerGen(x =>
      {
        {
          x.SwaggerDoc("v1", new OpenApiInfo { Title = "Store", Version = "v1" });
        }
      });

      services.AddElmahIo(o =>
      {
        o.ApiKey = "8113b6776a774f65bf7f4a9a4beb645f";
        o.LogId = new Guid("b6686d7c-f338-4fc2-b18d-be0fd943e628");
      });

      Settings.ConnectionString = $"{Configuration["connectionString"]}";
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();

      app.UseResponseCompression();

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store - v1");
      });

      app.UseElmahIo();

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapGet("/", async context =>
              {
                await context.Response.WriteAsync("Hello World!");
              });
      });
    }
  }
}
