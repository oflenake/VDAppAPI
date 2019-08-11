#region Proprietary Information
/* 
    * Created by:   Vision-Dream ICT Solutions
    * Author:       Onkgopotse Lenake
    * Email:        visiondreamict@gmail.com
    * Website:      www.visiondreamict.wordpress.com
    * 
    *               (c) 2019 Vision-Dream ICT Solutions. All rights reserved.
    * _______________________________________________________________________
    * Project:      Vision-Dream .Net Core Web Application API
    *               Project Targeting .Net Core 2.2.
    * Version:      v1.0.0
    * File:         Startup.cs
    * Date:         2019-01-10
    * Description:  This file contains the Startup class. 
    *               Class execution code.
*/
#endregion

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Vision_Dream.Models;
using Vision_Dream.Extensions;
using Vision_Dream.Middlewares;
using NLog;

namespace VDAppAPI
{
    public class Startup
    {
        public static string _AppName { get; set; }
        public static string _AppVersion { get; set; }
        public IConfiguration _Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/NLog-File.config"));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = _Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<AppSettings>(appSettingsSection);

            // Configure Jwt authentication
            _AppName = appSettings.AppName;
            _AppVersion = "v1.0";
            var key = Encoding.ASCII.GetBytes(appSettings.ServerSecrete);

            services.ConfigureCors();
            services.ConfigureIIS();
            services.ConfigureLogger();
            services.ConfigureSQLTransactionalDEV(_Configuration);
            //services.AddSwaggerDocumentation();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ExceptionFilterMiddleware));
            })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
