using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace WebApiTemplateDDD.Api.Versioning
{
    /// <summary>
    /// Configures SwaggerUIOptions for use with api versioning.
    /// </summary>
    public class ConfigureVersionedSwaggerUIOptions : IConfigureOptions<SwaggerUIOptions>
    {
        private readonly IApiVersionDescriptionProvider _versionProvider;

        /// <summary>
        /// Creates an instance.
        /// </summary>
        /// <param name="versionProvider">The api version description provider.</param>
        public ConfigureVersionedSwaggerUIOptions(IApiVersionDescriptionProvider versionProvider)
        {
            _versionProvider = versionProvider;
        }

        /// <summary>
        /// Configures the options instance for use with api versioning.
        /// </summary>
        /// <param name="options">The options instance</param>
        public void Configure(SwaggerUIOptions options)
        {
            foreach (var description in _versionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
        }
    }
}