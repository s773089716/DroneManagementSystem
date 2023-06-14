using DroneManagementSystem.DependencyResolution;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Caching.Memory;

namespace DroneManagementSystem
{
    public class Startup
    {
        private ILoggerFactory _loggerFactory = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            

            app.UseMvc();
        }
    }
}
