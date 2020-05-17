namespace api.Features.Authorization
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="ForbiddenProblemDetails" />.
    /// </summary>
    public class ForbiddenProblemDetails : ProblemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenProblemDetails"/> class.
        /// </summary>
        /// <param name="details">The details<see cref="string"/>.</param>
        public ForbiddenProblemDetails(string details = null)
        {
            Title = "Forbidden";
            Detail = details;
            Status = 403;
            Type = "https://httpstatuses.com/403";
        }
    }
}