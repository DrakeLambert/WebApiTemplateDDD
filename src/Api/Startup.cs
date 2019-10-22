using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiTemplateDDD.Api.Swagger;
using WebApiTemplateDDD.Api.Versioning;
using Serilog;

namespace WebApiTemplateDDD.Api
{
    /// <summary>
    /// Configures the service collection and request pipeline.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Creates an instance.
        /// </summary>
        /// <param name="configuration">The app configuration to use.</param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        /// <summary>
        /// Configures a service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddVersioning();
            services.AddSwagger();
        }

        /// <summary>
        /// Configures the request pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The hosting environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
