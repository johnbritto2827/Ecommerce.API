using ECommerce.DBEngine;
using ECommerce.Repository;
using ECommerce.Repository.Vendor;
using ECommerce.Services;
using ECommerce.Services.Vendor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace ECommerce.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container...
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISQLServerHandler, SQLServerHandler>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddTransient<IUserDetailRepository, UserDetailRepository>();
            services.AddTransient<IUserDetailService, UserDetailService>();

            services.AddTransient<IProductDetailsRepository, ProductDetailsRepository>();
            services.AddTransient<IProductDetailsService, ProductDetailsService>();

            services.AddTransient<IVendorDetailsRepository, VendorDetailsRepository>();
            services.AddTransient<IVendorDetailsService, VendorDetailsService>();


            #region Configure Swagger Basic Auth

            services.AddSwaggerGen();


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ECommerce.API",
                    Description = "ECommerce API Service Web API for managing ToDo items",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });
            });

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechTalk React JS API Services", Version = "v1" });
            //    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
            //    {
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.Http,
            //        Scheme = "basic",
            //        In = ParameterLocation.Header,
            //        Description = "Basic Authorization header using the Bearer scheme."
            //    });
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //              new OpenApiSecurityScheme
            //                {
            //                    Reference = new OpenApiReference
            //                    {
            //                        Type = ReferenceType.SecurityScheme,
            //                        Id = "basic"
            //                    }
            //                },
            //                new string[] {}
            //        }
            //    });
            //});


            //services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            #endregion




            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce API Services"));
        }
    }
}
