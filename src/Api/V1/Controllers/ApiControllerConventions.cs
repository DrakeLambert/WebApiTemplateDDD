#pragma warning disable IDE0060

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace WebApiTemplateDDD.Api.V1.Controllers
{
    /// <summary>
    /// Common api conventions for all api controllers.
    /// </summary>
    public static class ApiControllerConventions
    {
        /// <summary>
        /// Convention for 'Get One' style actions with an id parameter.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Get([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix), ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.AssignableFrom)] object id, params object[] args)
        { }

        /// <summary>
        /// Convention for 'List All' style actions with no parameters.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void List()
        { }

        /// <summary>
        /// Convention for 'List Some' style actions with filter parameters.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void List(params object[] args)
        { }
    }
}
