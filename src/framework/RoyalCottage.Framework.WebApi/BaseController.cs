using Microsoft.AspNetCore.Mvc;
using RoyalCottage.Framework.Core.Models;
using RoyalCottage.Framework.WebApi.Filters;
using RoyalCottage.Framework.WebApi.HttpActionResult;
using System;
using System.Net;
using System.Net.Http.Headers;

namespace RoyalCottage.Framework.WebApi
{
    [ApplicationContextFilter]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public abstract class BaseController :  Controller
    {
        public ApplicationContext Context;

        internal void SetContext()
        {
            //TODO: Get from header
            if (Context == null) Context = new ApplicationContext() { TenantId = new Guid("F57B635C-2BAE-485A-BC4F-E3E8B6483504") };
        }

        public IActionResult Respond<T>(BusinessResponse<T> businessResult, string type = null, string key = null)
            where T : EntityBase
        {
            switch (businessResult?.Status)
            {
                case BusinessStatus.Ok:
                    return Ok(businessResult);
                case BusinessStatus.Created:
                    return Created($"/api/{type}/{key}", businessResult);
                case BusinessStatus.Updated:
                    return Custom(HttpStatusCode.OK, businessResult);
                case BusinessStatus.NotFound:
                    return NotFound();
                case BusinessStatus.Deleted:
                    return Custom(HttpStatusCode.OK, businessResult);
                case BusinessStatus.NothingModified:
                    return Custom(HttpStatusCode.NotModified, businessResult);
                case BusinessStatus.Error:
                    return Custom(HttpStatusCode.InternalServerError, businessResult);
                case BusinessStatus.PreConditionFailed:
                    return Custom(HttpStatusCode.BadRequest, businessResult.Errors);
                case BusinessStatus.InputValidationFailed:
                    return Custom(HttpStatusCode.BadRequest, businessResult.Errors);
                case BusinessStatus.NotImplemented:
                    return Custom(HttpStatusCode.NotImplemented, businessResult);
                case BusinessStatus.UnAuthorized:
                    return Unauthorized();
                case BusinessStatus.ServiceUnAvailable:
                    return Custom(HttpStatusCode.ServiceUnavailable, businessResult.Errors);
                case BusinessStatus.KeyAlreadyExists:
                    return Custom(HttpStatusCode.BadRequest, businessResult.Errors);
                default:
                    return Custom(HttpStatusCode.InternalServerError, businessResult);
            }
        }

        protected CustomNegotiatedContentResult<T> Custom<T>(HttpStatusCode statusCode, T content)
        {
            return new CustomNegotiatedContentResult<T>(statusCode, content);
        }

        /// <summary>
        /// Custom Result with http status code as "201"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="location">Http location header</param>
        /// <param name="content">T - Content</param>
        /// <param name="version">Version - Required to create etag for concurrency check.</param>
        /// <returns>CustomNegotiatedContentResult</returns>
        protected CustomNegotiatedContentResult<T> Created<T>(string location, T content, Byte[] version)
        {
            return Custom(HttpStatusCode.Created, content);
        }

        /// <summary>
        /// Custom Result with http status code as "200"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content">T - Content</param>
        /// <param name="version">Version - Required to create etag for concurrency check.</param>
        /// <returns>CustomNegotiatedContentResult</returns>
        protected CustomNegotiatedContentResult<T> Ok<T>(T content, Byte[] version)
        {
            return Custom(HttpStatusCode.OK, content);
        }

        /// <summary>
        /// Create etag.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        protected EntityTagHeaderValue CreateETag(byte[] version)
        {
            return new EntityTagHeaderValue("\"" +
                                            Convert.ToBase64String(version,
                                                Base64FormattingOptions.None) + "\"");
        }

        /// <summary>
        /// Gets ETag from request (If-Match header)
        /// </summary>
        /// <returns></returns>
        protected byte[] GetETag()
        {
            //// if the request contains an If-Match header with a non-empty ETag
            //var firstHeaderVal = Request?.Headers?.IfMatch?.FirstOrDefault();
            //if (!string.IsNullOrEmpty(firstHeaderVal?.Tag) && (firstHeaderVal.Tag != "*"))
            //{
            //    var encodedNewTagValue = firstHeaderVal.Tag.Trim("\"".ToCharArray());
            //    return Convert.FromBase64String(encodedNewTagValue);
            //}
            return null;
        }

    }
}
