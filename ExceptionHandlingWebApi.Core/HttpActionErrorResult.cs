using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ExceptionHandlingWebAPI.Core
{
    public class HttpActionErrorResult : IHttpActionResult
    {
        private readonly HttpRequestMessage request;

        private readonly HttpStatusCode statusCode;

        private readonly string message;

        public HttpActionErrorResult(HttpRequestMessage request, HttpStatusCode statusCode, string message)
        {
            this.request = request;
            this.statusCode = statusCode;
            this.message = message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = request.CreateErrorResponse(statusCode, message);
            return Task.FromResult(response);
        }
    }
}