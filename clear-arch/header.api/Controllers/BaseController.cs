namespace api.Controllers
{
    using api.Features.Authorization;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="BaseController" />.
    /// </summary>
    [Authorize(Policies.OnlyEmployees)]
    [Route("[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Defines the _mediator.
        /// </summary>
        private IMediator _mediator;

        /// <summary>
        /// Gets the Mediator.
        /// </summary>
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        /// <summary>
        /// The GeneratePageLinks.
        /// </summary>
        /// <param name="pageNumber">The pageNumber<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <param name="pageCount">The pageCount<see cref="int"/>.</param>
        /// <param name="url">The url<see cref="IUrlHelper"/>.</param>
        /// <returns>The <see cref="Dictionary{string, string}"/>.</returns>
        protected Dictionary<string, string> GeneratePageLinks(int pageNumber, int pageSize, int pageCount, IUrlHelper url)
        {
            return new Dictionary<string, string>(){
                { "First", url.RouteUrl(new { pageNumber = 1, pageSize }) },
                { "Last", url.RouteUrl(new { pageNumber = pageCount, pageSize }) },
                { "Previous", url.RouteUrl(new { pageNumber = pageNumber - 1, pageSize }) },
                { "Next", url.RouteUrl(new { pageNumber = pageNumber + 1, pageSize }) }
            };
        }

        protected void IssueKey(LoggedUser T)
        {
            if (T == null) return;
            var key = HttpContext.Request.Headers["X-Api-Key"];

            T.SetUserApiKey(key);
        }
    }
}