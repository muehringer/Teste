using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Teste.Infrastructure.Configurations;
using Teste.Application.Interfaces;
using Teste.Application.App;

namespace Teste.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(c => {
                c.SwaggerDoc(Configuration["SwaggerVersion"].ToString(),
                new Info {
                    Title = Configuration["SwaggerTitle"].ToString(),
                    Version = Configuration["SwaggerVersion"].ToString(),
                    Description = Configuration["SwaggerDescription"].ToString(),
                    TermsOfService = "None",
                    Contact = new Contact { Name = Configuration["SwaggerContactName"].ToString(), Email = Configuration["SwaggerContactEmail"].ToString(), Url = Configuration["SwaggerContactUrl"].ToString() }
                });
            });

            services.AddCors();
            services.AddOptions();
            services.Configure<KeysConfig>(Configuration);
            services.AddAutoMapper();

            services.AddScoped(typeof(IFeedApp), typeof(FeedApp));

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddResponseCompression();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()
            );
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", Configuration["SwaggerTitle"].ToString());
            });
            app.UseResponseCompression();
        }
    }
}
