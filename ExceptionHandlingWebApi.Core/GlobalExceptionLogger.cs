using ExceptionHandlingWebAPI.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace ExceptionHandlingWebAPI.Core
{
    public class GlobalExceptionLogger : IExceptionLogger
    {
        private readonly ILogger logger;

        public GlobalExceptionLogger(ILogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// This is customize implementation of default Exception Logger
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task LogAsync(ExceptionLoggerContext context, System.Threading.CancellationToken cancellationToken)
        {
            var logSchema = new LogSchema();
            logSchema.Exception = context.Exception;
            logSchema.Message = context.Exception.Message;
            if (context.ExceptionContext != null && context.ExceptionContext.ControllerContext != null && context.ExceptionContext.ControllerContext.ControllerDescriptor != null)
            {
                logSchema.ControllerName = context.ExceptionContext.ControllerContext.ControllerDescriptor.ControllerName ?? string.Empty;
                var actionContext = ((System.Web.Http.ApiController)context.ExceptionContext.ControllerContext.Controller).ActionContext;
                if (actionContext != null && actionContext.ActionDescriptor != null)
                    logSchema.MethodName = actionContext.ActionDescriptor.ActionName;
                logSchema.EventId = 1;
                logSchema.MessageId = 1;//set based on exception type;
            }
            await logger.LogAsync(logSchema);
        }
    }
}