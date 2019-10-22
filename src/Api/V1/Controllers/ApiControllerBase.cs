using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTemplateDDD.Api.V1.Controllers
{
    /// <summary>
    /// A base controller for all api controllers.
    /// </summary>
    [ApiController]
    [ApiConventionType(typeof(ApiControllerConventions))]
    [Authorize]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    { }
}