using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApiTemplateDDD.Api.Versioning
{
    /// <summary>
    /// Configures SwaggerGenOptions for use with api versioning.
    /// </summary>
    public class ConfigureVersionedSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider _versionProvider;

        /// <summary>
        /// Creates an instance.
        /// </summary>
        /// <param name="versionProvider">The api version description provider.</param>
        public ConfigureVersionedSwaggerGenOptions(IApiVersionDescriptionProvider versionProvider) => _versionProvider = versionProvider;

        /// <summary>
        /// Configures the options instance for use with api versioning.
        /// </summary>
        /// <param name="options">The options instance</param>
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _versionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    new OpenApiInfo()
                    {
                        Title = $"{typeof(Startup).Namespace}",
                        Version = description.ApiVersion.ToString(),
                    });
            }
        }
    }
}