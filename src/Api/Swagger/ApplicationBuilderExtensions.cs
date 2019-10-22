using Microsoft.AspNetCore.Builder;

namespace WebApiTemplateDDD.Api.Swagger
{
    /// <summary>
    /// Extensions for adding swagger to the request pipeline.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds swagger documents and UI to the request pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <returns>The application builder.</returns>
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app)
        {
            SwaggerBuilderExtensions.UseSwagger(app);
            app.UseSwaggerUI();

            return app;
        }
    }
}