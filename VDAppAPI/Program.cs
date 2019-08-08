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
    *               Project Targeting .Net Core 2.1.
    * Version:      v1.0.0
    * File:         Program.cs
    * Date:         2019-01-10
    * Description:  This file contains the Program class. 
    *               Class execution code.
*/
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Vision_Dream.AppModels;
using NLog.Web;

namespace VDAppAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // NLog: Setup the loggerWeb first to catch all errors
            var loggerWeb = NLogBuilder.ConfigureNLog("NLog-File.config").GetCurrentClassLogger();

            try
            {
                loggerWeb.Debug("VDAppAPI starting up and executing main.");
                BuildWebHost(args).Build().Run();
                loggerWeb.Info("VDAppAPI starting up and executing main.");
            }
            catch (Exception ex)
            {
                // NLog: Catch setup errors
                loggerWeb.Error(ex, "VDAppAPI stopped because of an exception.");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog();  // NLog: Setup NLog for dependency injection
    }
}
