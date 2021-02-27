using FavoDeMel.API.Configuration;
using FavoDeMel.API.Options;
using FavoDeMel.Infra.Dapper.Base;
using GreenPipes;
using HealthChecks.UI.Client;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PacoEvento.Infra.Data.Context;
using System;
using System.IO;
using System.Reflection;

namespace FavoDeMel.API
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddOptions();

            RabbitMQOptions rabbitMqOptions = new RabbitMQOptions();
            Configuration.GetSection("RABBITMQOPTIONS").Bind(rabbitMqOptions);

            services.AddAutoMapperSetup();

            services.AddDbContext<FavoDeMelContext>(options =>
                options
                .UseSqlServer(Configuration.GetConnectionString("FAVODEMEL_CONNECTION_STRING"))
                .UseLazyLoadingProxies());

            services.AddTransient<ISqlConnectionFactory>(c => new SqlConnectionFactory(Configuration.GetConnectionString("FAVODEMEL_CONNECTION_STRING")));

            services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                Uri hostAddress = new Uri(rabbitMqOptions.Host);

                cfg.Host(hostAddress, h =>
                {
                    h.Username(rabbitMqOptions.User);
                    h.Password(rabbitMqOptions.Password);
                });

                cfg.UseConcurrencyLimit(1);
            }));

            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                builder => builder.WithOrigins("http://localhost:8081", "http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowAnyMethod());
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(Path.ChangeExtension(Assembly.GetAssembly(typeof(Startup)).Location, "xml"));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FavoDeMel - Manager de Cozinha",
                    Version = "v1",
                    Description = ""
                });
            });

            services.AddHealthChecks()
                .AddRabbitMQ("amqp://favomel:RabbitMQ2019!@localhost:5672", name: "rabbitMQ")
                .AddSqlServer(connectionString: Configuration.GetConnectionString("FAVODEMEL_CONNECTION_STRING"));

            // services.AddHealthChecksUI();

            services.AddMediatR(typeof(Startup));

            services.AddDependencyInjectionSetup();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else{
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowOrigin");

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint($"/swagger/v1/swagger.json", "FavoDeMel - Manager v1.0");
            });

            //app.UseHealthChecks("/healthchecks-data-ui", new HealthCheckOptions()
            //{
            //    Predicate = _ => true,
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //});

            //app.UseHealthChecksUI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
