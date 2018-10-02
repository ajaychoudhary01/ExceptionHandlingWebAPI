using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace ExceptionHandlingWebAPI.Core
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// This is customize implementation of Exception Handler
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task HandleAsync(ExceptionHandlerContext context, System.Threading.CancellationToken cancellationToken)
        {            
            HttpStatusCode statusCode;
            var exception = context.Exception;
            var isClientMistake = IsClientMistake(exception, out statusCode);
            string message = isClientMistake ? exception.Message : HttpStatusCode.InternalServerError.ToString();
            HttpActionErrorResult result = new HttpActionErrorResult(context.Request, statusCode, message);
            context.Result = result;
            return Task.FromResult(0);                
        }

        /// <summary>
        /// This method will check exception type
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        private bool IsClientMistake(Exception exception, out HttpStatusCode httpStatusCode)
        {
            var isClientMistake = false;
            if (exception is UnauthorizedAccessException)
            {
                httpStatusCode = HttpStatusCode.Unauthorized;
                isClientMistake = true;
            }
            if (exception is InvalidOperationException)
            {
                httpStatusCode = HttpStatusCode.Forbidden;
                isClientMistake = true;
            }
            if(exception is ArgumentOutOfRangeException)
            {
                httpStatusCode = HttpStatusCode.NotFound;
                isClientMistake = true;
            }
            else if(exception is ArgumentException  || exception is SerializationException || exception is NotSupportedException
                || exception is HttpRequestException)
            {
                httpStatusCode = HttpStatusCode.BadRequest;
                isClientMistake = true;
            }
            else 
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
            }
            return isClientMistake;
        }
    }
}