namespace api.Filters
{
    using application.exceptions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="CustomExceptionFilterAttribute" />.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// The OnException.
        /// </summary>
        /// <param name="context">The context<see cref="ExceptionContext"/>.</param>
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(
                    ((ValidationException)context.Exception).Failures);

                return;
            }

            var code = HttpStatusCode.InternalServerError;

            if (context.Exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }

            if (context.Exception is DuplicateIndexException)
            {
                code = HttpStatusCode.Conflict;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message, context.Exception.InnerException != null ? context.Exception.InnerException.Message : "No inner exception" },
                stackTrace = context.Exception.StackTrace
            });
        }
    }
}