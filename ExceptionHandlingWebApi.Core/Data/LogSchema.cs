using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExceptionHandlingWebAPI.Core.Data
{
    public class LogSchema
    {
        public Exception Exception { get; set; }

        public string Message { get; set; }

        public string ControllerName { get; set; }

        public string MethodName { get; set; }

        public int EventId { get; set; }

        public int MessageId { get; set; }

        public string MessageCode { get; set; }
    }
}