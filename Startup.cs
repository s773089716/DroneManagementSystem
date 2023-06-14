﻿using DroneManagementSystem.BackgroundServices;
using DroneManagementSystem.DependencyResolution;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using ILogger = Serilog.ILogger;
//using Microsoft.Extensions.Caching.Memory;

namespace DroneManagementSystem
{
    public class Startup
    {
        private SerilogLoggerFactory _loggerFactory = null;
        private readonly ILogger _serilogLogger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _serilogLogger = new LoggerConfiguration()
                    // attach sinks here
                    .WriteTo.File
                    (
                        "logs/log.log"
                        //,rollingInterval: RollingInterval.Hour
                    )
                    .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc().AddMvcOptions(EnableEnd);//.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddMemoryCache();
            services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
            //services.AddControllers().AddNewtonsoftJson();

            #region Dependency Resolution ---------------------------------------------------------
            services.RegisterServices(_loggerFactory);
            #endregion

            services.AddLogging(builder => {
                builder.AddSerilog(_serilogLogger);
            });

            services.AddHostedService<DroneBatteryLevelCheckerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            

            app.UseMvc();
        }
    }
}
