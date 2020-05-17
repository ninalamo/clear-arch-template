namespace api.Features.Authentication
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="UnauthorizedProblemDetails" />.
    /// </summary>
    public class UnauthorizedProblemDetails : ProblemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedProblemDetails"/> class.
        /// </summary>
        /// <param name="details">The details<see cref="string"/>.</param>
        public UnauthorizedProblemDetails(string details = null)
        {
            Title = "Unauthorized";
            Detail = details;
            Status = 401;
            Type = "https://httpstatuses.com/401";
        }
    }
}