﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage()
                    .UseDatabaseErrorPage();
            }

            app
                .Map("/api", api =>
                 {
                     api.UseCors(policy =>
                         {
                             if (env.IsDevelopment())
                             {
                                 policy.AllowAnyHeader();
                                 policy.AllowAnyMethod();
                                 policy.AllowAnyOrigin();
                                 policy.AllowCredentials();

                             }

                             if (env.IsProduction())
                             {
                                 policy.AllowAnyHeader();
                                 policy.AllowAnyMethod();
                                 policy.AllowCredentials();

                                 policy.WithOrigins("www.fyseg.com");
                             }
                         })
                         .UseAuthentication()
                         .UseMvc();
                 })

                 .Run(context => context.Response.WriteAsync("Application Started"));
        }
    }
}