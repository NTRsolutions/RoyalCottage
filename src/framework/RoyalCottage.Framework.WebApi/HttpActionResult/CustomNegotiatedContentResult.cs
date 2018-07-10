using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace RoyalCottage.Framework.WebApi.HttpActionResult
{
    /// <summary>
    /// Represents an action result that performs content negotiation.
    /// </summary>
    /// <typeparam name="T">Type T</typeparam>
    public class CustomNegotiatedContentResult<T> : NegotiatedContentResult<T>
    {
        /// <summary>
        /// CustomNegotiatedContentResult constructor
        /// </summary>
        /// <param name="statusCode">Status code</param>
        /// <param name="content">Content</param>
        /// <param name="contentNegotiator">Content negotiator</param>
        /// <param name="request">Request object</param>
        /// <param name="formatters">Formatter</param>
        public CustomNegotiatedContentResult(HttpStatusCode statusCode, T content)
            : base(statusCode, content)
        {
        }

        /// <summary>
        /// Executes asynchronously an HTTP negotiated content results.
        /// </summary>
        /// <returns>
        /// Asynchronously executes an HTTP negotiated content results.
        /// </returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        public override Task ExecuteResultAsync(ActionContext actionContext)
        {
           return base.ExecuteResultAsync(actionContext);
        }
    }
}
